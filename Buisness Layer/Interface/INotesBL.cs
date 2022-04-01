using Common_Layer.Models;
using Microsoft.AspNetCore.Http;
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
        public IEnumerable<NotesEntity> GetNotes(long noteId);
        public IEnumerable<NotesEntity> GetNotesTableData();
        public bool DeleteNotes(long noteId);
        public NotesEntity IsPinned(long noteId);
        public NotesEntity IsTrash(long noteId);
        public NotesEntity IsArchive(long noteId);
        public NotesEntity ColorChange(long noteId, string color);
        public NotesEntity UploadImage(long noteId, IFormFile image);
    }
}
