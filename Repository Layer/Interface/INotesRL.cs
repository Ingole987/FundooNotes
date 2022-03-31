using Common_Layer.Models;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Interface
{
    public interface INotesRL
    {
        public NotesEntity CreateNotes(UserNotes userNotes, long userId);
        public NotesEntity UpdateNotes(UpdateModel noteUpdate, long noteId);

        public bool DeleteNotes(long noteId);

        public IEnumerable<NotesEntity> GetNotes(long userId);

        public IEnumerable<NotesEntity> GetNotesTableData();
    }
}
