﻿using Common_Layer.Models;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
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
                notesEntity.CreateAt = userNotes.CreateAt;
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
            catch (Exception ex)
            {

                throw ex;

            }
        }
    }
}