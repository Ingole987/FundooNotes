using Buisness_Layer.Interface;
using Common_Layer.Models;
using Microsoft.AspNetCore.Http;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness_Layer.Service
{
    public class NotesBL : INotesBL
    {
        private readonly INotesRL notesRL;
        public NotesBL(INotesRL notesRL)
        {
            this.notesRL = notesRL;
        }

        public NotesEntity CreateNotes(UserNotes usernotes, long userId)
        {
            try
            {

                return notesRL.CreateNotes(usernotes, userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public NotesEntity UpdateNotes(UpdateModel noteUpdate, long noteId)
        {
            try
            {
                return notesRL.UpdateNotes(noteUpdate, noteId);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        


        
        public IEnumerable<NotesEntity> GetNotes(long noteId)
        {
            try
            {
                return notesRL.GetNotes(noteId);
                ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        public IEnumerable<NotesEntity> GetNotesTableData()
        {
            try
            {
                return notesRL.GetNotesTableData();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteNotes(long noteId)
        {
            try
            {
                return notesRL.DeleteNotes(noteId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public NotesEntity IsPinned(long noteId)
        {
            try
            {
                return notesRL.IsPinned(noteId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public NotesEntity IsTrash(long noteId)
        {
            try
            {
                return notesRL.IsTrash(noteId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public NotesEntity IsArchive(long noteId)
        {
            try
            {
                return notesRL.IsArchive(noteId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public NotesEntity ColorChange(long noteId, string color)
        {
            try
            {
                return notesRL.ColorChange(noteId, color);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public NotesEntity UploadImage(long noteId, IFormFile image)
        {
            try
            {
                return notesRL.UploadImage(noteId, image);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }

}
