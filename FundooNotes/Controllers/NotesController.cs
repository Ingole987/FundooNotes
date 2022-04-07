using Buisness_Layer.Interface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Common_Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("Create")]
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

                return NotFound(new { success = false, message = " Something went wrong" }); ;
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateNotes(UpdateModel notesUpdate, long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                if (noteId <= 0)
                    return BadRequest(new { success = false, message = "Note Id Should Be Greater Than Zero" });
                var result = notesBL.UpdateNotes(notesUpdate, noteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Note updated", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "No note found" });
            }
            catch (Exception)
            {

                return this.NotFound(new { success = false, message = " Something went wrong" });
            }
        }

        [HttpGet("Get")]
        public IActionResult GetNotes(long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = notesBL.GetNotes(noteId);
                if (result != null)
                    return this.Ok(new { Success = true, data = result });
                else
                    return this.BadRequest(new { Success = false, });
            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" }); ;
            }

        }

        [HttpGet("GetAllNotes")]
        public IActionResult GetNotesTableData()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = notesBL.GetNotesTableData();
                if (result != null)
                    return this.Ok(new { Success = true, data = result });
                else
                    return this.BadRequest(new { Success = false, });
            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" }); ;
            }

        }
        [HttpDelete("Delete")]
        public IActionResult DeleteNotes(long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                if (noteId <= 0)
                    return BadRequest(new { success = false, message = "Note Id Should Be Greater Than Zero" });
                var result = notesBL.DeleteNotes(noteId);
                if (result)
                    return this.Ok(new { Success = true, message = "Deleted", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Not Deleted" });
            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" });
            }
        }

        [HttpPatch("IsPinned")]
        public IActionResult IsPinned(long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                if (noteId <= 0)
                    return BadRequest(new { success = false, message = "Note Id Should Be Greater Than Zero" });
                var result = notesBL.IsPinned(noteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Note Is Pinned", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Note Is Not Pinned" });

            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" });
            }
        }

        [HttpPatch("IsTrash")]
        public IActionResult IsTrash(long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                if (noteId <= 0)
                    return BadRequest(new { success = false, message = "Note Id Should Be Greater Than Zero" });
                var result = notesBL.IsTrash(noteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Note Is Trashed", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Note is not Trashed" });

            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" });
            }
        }

        [HttpPatch("IsArchieve")]
        public IActionResult IsArchive(long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                if (noteId <= 0)
                    return BadRequest(new { success = false, message = "Note Id Should Be Greater Than Zero" });
                var result = notesBL.IsArchive(noteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Note Is Archieved", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Note is not Archieved" });

            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" });
            }
        }

        [HttpPut("ColorChange")]
        public IActionResult ColorChange(long noteId, string color)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                if (noteId <= 0)
                    return BadRequest(new { success = false, message = "Note Id Should Be Greater Than Zero" });
                var result = notesBL.ColorChange(noteId, color);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Color change successfully", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Color change failed" });
            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" });
            }
        }

        [HttpPost("Upload/{Image}")]
        public IActionResult UploadImage(long noteId, IFormFile image)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                if (noteId <= 0)
                    return BadRequest(new { success = false, message = "Note Id Should Be Greater Than Zero" });
                var result = notesBL.UploadImage(noteId, image);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Image ulpoaded successfully", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Image Upload fail" });
            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" });
            }


        }

        [HttpDelete("Delete/{Image}")]
        public IActionResult DeleteImage(long noteId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                if (noteId <= 0)
                    return BadRequest(new { success = false, message = "Note Id Should Be Greater Than Zero" });
                var result = notesBL.DeleteImage(noteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Image Deleted successfully", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Image Delete fail" });
            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" });
            }


        }
    }
}


