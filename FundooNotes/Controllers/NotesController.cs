using Buisness_Layer.Interface;
using Common_Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : Controller
    {
        private readonly INotesBL notesBL;

        public NotesController(INotesBL notesBL)
        {
            this.notesBL = notesBL;
        }
        
        [HttpPost("CreateNotes")]
        public IActionResult CreateNotes(UserNotes userNotes)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = notesBL.CreateNotes(userNotes, userId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Note Added", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Nothing saved" });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateNotes(UpdateModel notesUpdate, long notesId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = notesBL.UpdateNotes(notesUpdate, notesId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Note updated", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "No note found" });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("Get/NotesID")]
        public IEnumerable<NotesEntity> GetNotes(long userId)
        {
            try
            {
                userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = notesBL.GetNotes(userId);
                if (result != null)
                    return result;
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("GetAllNotes")]
        public IEnumerable<NotesEntity> GetNotesTableData()
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = notesBL.GetNotesTableData();
                if (result != null)
                    return result;
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteNotes(long notesId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = notesBL.DeleteNotes(notesId);
                if (result)
                    return this.Ok(new { Success = true, message = "Deleted", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Not Deleted" });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch("IsPinned")]
        public IActionResult IsPinned(long userId, long NoteId)
        {
            try
            {
                userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = notesBL.IsPinned(userId, NoteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Deleted", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Not Deleted" });

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch("IsTrash")]
        public IActionResult IsTrash(long userId, long NoteId)
        {
            try
            {
                userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = notesBL.IsTrash(userId, NoteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Deleted", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Not Deleted" });

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch("IsArchieve")]
        public IActionResult IsArchive(long userId,long NoteId)
        {
            try
            {
                userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = notesBL.IsArchive(userId, NoteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Deleted", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Not Deleted" });

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

