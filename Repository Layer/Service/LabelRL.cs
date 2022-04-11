using Common_Layer.Models;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository_Layer.Service
{
    public class LabelRL : ILabelRL
    {
        private readonly FundooContext fundooContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fundooContext"></param>
        public LabelRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="noteslabel"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public LabelEntity AddLabel(NotesLabel noteslabel , long userId)
        {
            try
            {
                var resLabel = fundooContext.LabelTable.Where(e => e.UserId == userId).FirstOrDefault();
                if (resLabel != null)
                {
                    LabelEntity newLabel = new LabelEntity();
                    newLabel.Label = noteslabel.Label;
                    newLabel.NoteId = noteslabel.NoteId;
                    newLabel.UserId = userId;
                    fundooContext.LabelTable.Add(newLabel);
                    int result = fundooContext.SaveChanges();
                    if (result > 0)
                    {
                        return newLabel;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="userId"></param>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public LabelEntity Update(string label, long userId, long labelId)
        {
            try
            {
                var result = fundooContext.LabelTable.Where(e => e.LabelId == labelId).FirstOrDefault();
                if (result != null)
                {
                    LabelEntity newlabel = new LabelEntity();
                    newlabel.Label = label;
                    fundooContext.LabelTable.Update(result);
                    fundooContext.SaveChanges();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public bool Delete(long labelId)
        {
            try
            {
                var result = fundooContext.LabelTable.Where(e => e.LabelId == labelId).FirstOrDefault();
                if (result != null)
                {
                    fundooContext.LabelTable.Remove(result);
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public IEnumerable<LabelEntity> GetLabel(long noteId)
        {
            try
            {
                var result = fundooContext.LabelTable.Where(x => x.NoteId == noteId).ToList();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;


                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LabelEntity> GetLabelTableData()
        {
            try
            {
                var result = fundooContext.LabelTable.ToList();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
