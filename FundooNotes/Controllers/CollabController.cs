using Buisness_Layer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CollabController : Controller
    {
        private readonly ICollabBL collabBL;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;
        public CollabController(ICollabBL collabBL, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.collabBL = collabBL;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
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

        [HttpGet("redis")]
        public async Task<IActionResult> GetAllCustomersUsingRedisCache()
        {
            var cacheKey = "Notes";
            string serializedNotes;
            var Notes = new List<CollabEntity>();
            var redisNotes = await distributedCache.GetAsync(cacheKey);
            if (redisNotes != null)
            {
                serializedNotes = Encoding.UTF8.GetString(redisNotes);
                Notes = JsonConvert.DeserializeObject<List<CollabEntity>>(serializedNotes);
            }
            else
            {
                Notes = collabBL.GetCollab().ToList();
                serializedNotes = JsonConvert.SerializeObject(Notes);
                redisNotes = Encoding.UTF8.GetBytes(serializedNotes);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redisNotes, options);
            }
            return Ok(Notes);
        }

    }
}
