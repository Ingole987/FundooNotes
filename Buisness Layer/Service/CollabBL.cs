using Buisness_Layer.Interface;
using Common_Layer.Models;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using Repository_Layer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness_Layer.Service
{
    public class CollabBL : ICollabBL
    {
        
        private readonly ICollabRL collabRL;
        public CollabBL(ICollabRL collabRL)
        {
            this.collabRL = collabRL;
        }
        

        public CollabEntity AddCollab(NotesCollab notesCollab, long userId)
        {
            try
            {
                return collabRL.AddCollab(notesCollab, userId);
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

        public IEnumerable<CollabEntity> GetCollab()
        {
            try
            {

                return collabRL.GetCollab();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
