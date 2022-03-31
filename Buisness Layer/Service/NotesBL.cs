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

    }
}
