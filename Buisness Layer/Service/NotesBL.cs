using Buisness_Layer.Interface;
using Common_Layer.Models;
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
        


        
        public IEnumerable<NotesEntity> GetNotes(long userId)
        {
            try
            {
                return notesRL.GetNotes(userId);
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

        public NotesEntity IsPinned(long userId, long NoteId)
        {
            try
            {
                return notesRL.IsPinned(userId, NoteId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public NotesEntity IsTrash(long userId, long NoteId)
        {
            try
            {
                return notesRL.IsTrash(userId, NoteId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public NotesEntity IsArchive(long userId,long NoteId)
        {
            try
            {
                return notesRL.IsArchive(userId, NoteId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }

}
