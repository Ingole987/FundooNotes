using Common_Layer.Models;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Interface
{
    public interface ICollabRL
    {
        public CollabEntity AddCollab(NotesCollab notesCollab, long userId);
        public bool DeleteCollab(long collabId);
        public IEnumerable<CollabEntity> GetCollab();
        
    }
}
