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
    public class CollabRL : ICollabRL
    {
        private readonly FundooContext fundooContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fundooContext"></param>
        public CollabRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notesCollab"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public CollabEntity AddCollab(NotesCollab notesCollab ,long userId)
        {
            try
            {
                var resCollab = fundooContext.UserTable.FirstOrDefault(x => x.Email == notesCollab.CollabEmailId);
                if (resCollab != null)
                {
                    CollabEntity newCollab = new CollabEntity() ;
                    newCollab.CollabEmailId = notesCollab.CollabEmailId;
                    newCollab.UserId = userId;
                    newCollab.NoteId = notesCollab.NoteId;
                    fundooContext.CollabTable.Add(newCollab);
                    var result = fundooContext.SaveChanges();
                    if (result > 0)
                    {
                        return newCollab;
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
        /// <param name="collabId"></param>
        /// <returns></returns>
        public bool DeleteCollab(long collabId)
        {
            try
            {
                var result = fundooContext.CollabTable.Where(x => x.CollabId == collabId).FirstOrDefault();
                if (result != null)
                {
                    fundooContext.CollabTable.Remove(result);
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
        /// <returns></returns>
        public IEnumerable<CollabEntity> GetCollab()
        {
            try
            {
                var result = fundooContext.CollabTable.ToList();
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
