using Buisness_Layer.Interface;
using Common_Layer.Models;
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
    public class LabelController : Controller
    {
        private readonly ILabelBL labelBL;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;
        public LabelController(ILabelBL labelBL, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.labelBL = labelBL;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }

        [HttpPost("Label")]
        public IActionResult AddLabel(NotesLabel noteslabel)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = labelBL.AddLabel(noteslabel , userId);
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
        public IActionResult Update(string label, long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = labelBL.Update(label, userId, noteId);
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

        [HttpDelete("Delete")]
        public IActionResult Delete(long labelId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = labelBL.Delete(labelId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Label Deleted", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Deletion Failed" });
            }
            catch (Exception)
            {

                return NotFound(new { success = false, message = " Something went wrong" }); ;
            }
        }

        [HttpPost("Get")]
        public IActionResult GetLabel(long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = labelBL.GetLabel(noteId);
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

        [HttpGet("GetAllLabel")]
        public IActionResult GetLabelTableData()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = labelBL.GetLabelTableData();
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

        [HttpGet("redis")]
        public async Task<IActionResult> GetAllCustomersUsingRedisCache()
        {
            var cacheKey = "Label";
            string serializedLabel;
            var Label = new List<LabelEntity>();
            var redisLabel = await distributedCache.GetAsync(cacheKey);
            if (redisLabel != null)
            {
                serializedLabel = Encoding.UTF8.GetString(redisLabel);
                Label = JsonConvert.DeserializeObject<List<LabelEntity>>(serializedLabel);
            }
            else
            {
                Label = labelBL.GetLabelTableData().ToList();
                serializedLabel = JsonConvert.SerializeObject(Label);
                redisLabel = Encoding.UTF8.GetBytes(serializedLabel);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redisLabel, options);
            }
            return Ok(Label);
        }
    }
}
