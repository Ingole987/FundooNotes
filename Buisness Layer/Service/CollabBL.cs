using Buisness_Layer.Interface;
using Repository_Layer.Entity;
using Repository_Layer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness_Layer.Service
{
    public class CollabBL : ICollabBL
    {
        
        private readonly ICollabBL collabRL;
        public CollabBL(ICollabBL collabRL)
        {
            this.collabRL = collabRL;
        }
        

        public CollabEntity AddCollab(string email, long userId, long noteId)
        {
            try
            {
                return collabRL.AddCollab(email, userId , noteId);
            }
                catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteCollab(long collabId)
        {
        try
        {

        return collabRL.DeleteCollab(collabId);
        }
        catch (Exception ex)
        {

        throw ex;
        }
        }

        public IEnumerable<CollabEntity> GetCollab(long noteId)
        {
        try
        {

        return collabRL.GetCollab(noteId);
        }
        catch (Exception ex)
        {

        throw ex;
        }
        }

        public IEnumerable<CollabEntity> GetCollabTableData()
        {
        try
        {

        return collabRL.GetCollabTableData();
        }
        catch (Exception ex)
        {

        throw ex;
        }
        }
    }
}
