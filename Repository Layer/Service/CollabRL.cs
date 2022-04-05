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

        public CollabRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public CollabEntity AddCollab(string email ,long userId , long noteId)
        {
            try
            {
                var result = fundooContext.UserTable.FirstOrDefault(x => x.Email == email);
                if (result.Email == email)
                {
                    CollabEntity collabEntity = new CollabEntity() ;
                    collabEntity.CollabEmailId = email;
                    collabEntity.UserId = userId;
                    collabEntity.NoteId = noteId;
                    fundooContext.CollabTable.Add(collabEntity);
                    fundooContext.SaveChanges();
                    return collabEntity;
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

        public IEnumerable<CollabEntity> GetCollab(long noteId)
        {
            try
            {
                var result = fundooContext.CollabTable.Where(x => x.NoteId == noteId).ToList();
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

        public IEnumerable<CollabEntity> GetCollabTableData()
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
