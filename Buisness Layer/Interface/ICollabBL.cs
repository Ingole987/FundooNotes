using Common_Layer.Models;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness_Layer.Interface
{
    public interface ICollabBL
    {
        public CollabEntity AddCollab(NotesCollab notesCollab, long userId);
        public bool DeleteCollab(long collabId);
        public IEnumerable<CollabEntity> GetCollab();
        
    }
}
