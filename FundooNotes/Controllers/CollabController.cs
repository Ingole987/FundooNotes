using Buisness_Layer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FundooNotes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CollabController : Controller
    {
        private readonly ICollabBL collabBL;

        public CollabController(ICollabBL collabBL)
        {
            this.collabBL = collabBL;
        }

        [HttpPost("Collab")]
        public IActionResult AddCollab(string email, long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = collabBL.AddCollab(email, userId, noteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Collab Successfull", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Collab Failed" });
            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" }); ;
            }
        }
        [HttpPost("Get")]
        public IActionResult GetCollab()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = collabBL.GetCollab();
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
        public IActionResult DeleteCollab(long collabId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = collabBL.DeleteCollab(collabId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Collab Removed", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Removal Failed" });
            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" }); ;
            }
        }
        
    }
}
