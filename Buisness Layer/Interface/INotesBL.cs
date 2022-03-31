using Common_Layer.Models;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness_Layer.Interface
{
    public interface INotesBL
    {
        public NotesEntity CreateNotes(UserNotes usernotes, long userId);
        public NotesEntity UpdateNotes(UpdateModel noteUpdate, long noteId);
        public IEnumerable<NotesEntity> GetNotes(long userId);
        public IEnumerable<NotesEntity> GetNotesTableData();
        public bool DeleteNotes(long noteId);
    }
}
