﻿using Repository_Layer.Context;
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

        public LabelRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }


        public LabelEntity AddLabel(string label, long userId, long noteId)
        {
            try
            {
                LabelEntity newLabel = new LabelEntity();
                newLabel.Label = label;
                newLabel.UserId = userId;
                newLabel.NoteId = noteId;
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
            catch (Exception)
            {

                throw;
            }
        }

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
    }
}
