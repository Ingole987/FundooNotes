using Common_Layer.Models;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository_Layer.Service
{
    public class NotesRL : INotesRL
    {
        private readonly FundooContext fundooContext;

        public NotesRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }


        public NotesEntity CreateNotes(UserNotes userNotes, long userId)
        {
            try
            {
                NotesEntity notesEntity = new NotesEntity();
                notesEntity.Title = userNotes.Title;
                notesEntity.Description = userNotes.Description;
                notesEntity.Reminder = userNotes.Reminder;
                notesEntity.Color = userNotes.Color;
                notesEntity.Image = userNotes.Image;
                notesEntity.IsArchive = userNotes.IsArchive;
                notesEntity.IsTrash = userNotes.IsTrash;
                notesEntity.IsPinned = userNotes.IsPinned;
                notesEntity.ModifiedAt = userNotes.ModifiedAt;
                notesEntity.CreateAt = userNotes.CreateAt = DateTime.Now;
                notesEntity.UserId = userId;
                fundooContext.NotesTable.Add(notesEntity);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                {
                    return notesEntity;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception )
            {

                throw ;

            }
        }

        public NotesEntity UpdateNotes(UpdateModel noteUpdate, long noteId)
        {
            try
            {
                var result = fundooContext.NotesTable.Where(e => e.NoteId == noteId).FirstOrDefault();
                if (result != null)
                {
                    result.Title = noteUpdate.Title;
                    result.Description = noteUpdate.Description;
                    result.Color = noteUpdate.Color;
                    result.Image = noteUpdate.Image;
                    result.ModifiedAt = noteUpdate.ModifiedAt = DateTime.Now;
                    fundooContext.NotesTable.Update(result);
                    fundooContext.SaveChanges();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<NotesEntity> GetNotes(long noteId)
        {
            try
            {
                var result = fundooContext.NotesTable.Where(x =>x.NoteId == noteId).ToList();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;


                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public IEnumerable<NotesEntity> GetNotesTableData()
        {
            try
            {
                var result = fundooContext.NotesTable.ToList();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool DeleteNotes(long noteId)
        {
            try
            {
                var result = fundooContext.NotesTable.Where(e => e.NoteId == noteId).FirstOrDefault();
                if (result != null)
                {
                    fundooContext.NotesTable.Remove(result);
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public NotesEntity IsPinned(long noteId)
        {
            try
            {
                NotesEntity newNote = fundooContext.NotesTable.FirstOrDefault(x =>x.NoteId == noteId);
                if (newNote != null)
                {
                    bool checkpin = newNote.IsPinned;
                    if (checkpin == true)
                    {
                        newNote.IsPinned = false;
                    }
                    if (checkpin == false)
                    {
                        newNote.IsPinned = true;
                    }
                    fundooContext.SaveChanges();
                    return newNote;
                }
                else
                {
                    return null;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NotesEntity IsTrash(long noteId)
        {
            try
            {
                NotesEntity newNote = fundooContext.NotesTable.FirstOrDefault(x =>x.NoteId == noteId);
                if (newNote != null)
                {
                    bool checkTrash = newNote.IsTrash;
                    if (checkTrash == true)
                    {
                        newNote.IsTrash = false;
                    }
                    if (checkTrash == false)
                    {
                        newNote.IsTrash = true;
                    }
                    fundooContext.SaveChanges();
                    return newNote;
                }
                else
                {
                    return null;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NotesEntity IsArchive(long noteId)
        {
            try
            {
                NotesEntity newNote = fundooContext.NotesTable.FirstOrDefault(x =>x.NoteId == noteId);
                if (newNote != null)
                {
                    bool checkArchive = newNote.IsArchive;
                    if (checkArchive == true)
                    {
                        newNote.IsArchive = false;
                    }
                    if (checkArchive == false)
                    {
                        newNote.IsArchive = true;
                    }
                    fundooContext.SaveChanges();
                    return newNote;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NotesEntity ColorChange(long noteId, string color)
        {
            try
            {
                NotesEntity newNote = fundooContext.NotesTable.FirstOrDefault(x =>x.NoteId == noteId);
                if (newNote != null)
                {
                    newNote.Color = color;
                    fundooContext.SaveChanges();
                    return newNote;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}