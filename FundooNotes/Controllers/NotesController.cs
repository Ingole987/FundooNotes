using Buisness_Layer.Interface;
using Common_Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
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
    }
}

