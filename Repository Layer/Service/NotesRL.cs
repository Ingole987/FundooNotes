using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Common_Layer.Models;
using Microsoft.AspNetCore.Http;
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
                    result.ModifiedAt = DateTime.Now;
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
                NotesEntity result = fundooContext.NotesTable.FirstOrDefault(x =>x.NoteId == noteId);
                if (result != null)
                {
                    bool checkpin = result.IsPinned;
                    if (checkpin == true)
                    {
                        result.IsPinned = false;
                    }
                    if (checkpin == false)
                    {
                        result.IsPinned = true;
                    }
                    result.ModifiedAt = DateTime.Now;
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
        public NotesEntity IsTrash(long noteId)
        {
            try
            {
                NotesEntity result = fundooContext.NotesTable.FirstOrDefault(x =>x.NoteId == noteId);
                if (result != null)
                {
                    bool checkTrash = result.IsTrash;
                    if (checkTrash == true)
                    {
                        result.IsTrash = false;
                    }
                    if (checkTrash == false)
                    {
                        result.IsTrash = true;
                    }
                    result.ModifiedAt = DateTime.Now;
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
        public NotesEntity IsArchive(long noteId)
        {
            try
            {
                
                NotesEntity result = fundooContext.NotesTable.FirstOrDefault(x =>x.NoteId == noteId);
                if (result != null)
                {
                    bool checkArchive = result.IsArchive;
                    if (checkArchive == true)
                    {
                        result.IsArchive = false;
                    }
                    if (checkArchive == false)
                    {
                        result.IsArchive = true;
                    }
                    result.ModifiedAt = DateTime.Now;
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

        public NotesEntity ColorChange(long noteId, string color)
        {
            try
            {
                NotesEntity result = fundooContext.NotesTable.FirstOrDefault(x =>x.NoteId == noteId);
                if (result != null)
                {
                    result.Color = color;
                    result.ModifiedAt = DateTime.Now;
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
        public NotesEntity UploadImage(long noteId, IFormFile image)
        {
            try
            {
                NotesEntity result = fundooContext.NotesTable.FirstOrDefault(x => x.NoteId == noteId);
                if (result != null)
                {
                    Account account = new Account(
                       "dvsoczosd",
                       "353786361236396",
                       "pgMX18MD59iFk3ztUcDJi5YhWcE");

                    Cloudinary cloudinary = new Cloudinary(account);

                    var imagepath = image.OpenReadStream();
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, imagepath),
                    };
                    var imageUploadParams = cloudinary.Upload(uploadParams);
                    result.Image = image.FileName;
                    fundooContext.NotesTable.Update(result);
                    result.ModifiedAt = DateTime.Now;
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

        public NotesEntity DeleteImage(long noteId)
        {
            try
            {
                NotesEntity result = fundooContext.NotesTable.FirstOrDefault(x => x.NoteId == noteId);
                //Account account = new Account(
                //       "dvsoczosd",
                //       "353786361236396",
                //       "pgMX18MD59iFk3ztUcDJi5YhWcE");

                if (result != null)
                {
                    result.Image = null;
                    //Cloudinary cloudinary = new Cloudinary(account);
                    //var deletionParams = new DeletionParams("image");
                    //var result = cloudinary.Destroy(deletionParams);
                    //fundooContext.NotesTable.Update(newNote);
                    result.ModifiedAt = DateTime.Now;
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

    }
}