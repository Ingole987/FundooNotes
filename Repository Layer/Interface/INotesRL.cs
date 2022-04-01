using Common_Layer.Models;
using Microsoft.AspNetCore.Http;
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

        public IEnumerable<NotesEntity> GetNotes(long noteId);

        public IEnumerable<NotesEntity> GetNotesTableData();
        public NotesEntity IsPinned(long noteId);
        public NotesEntity IsTrash(long noteId);
        public NotesEntity IsArchive(long noteId);
        public NotesEntity ColorChange(long noteID, string color);
        public NotesEntity UploadImage(long noteId, IFormFile image);
    }
}
