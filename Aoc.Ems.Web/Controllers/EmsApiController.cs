using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aoc.Ems.Core;
using Aoc.Ems.Data;

namespace Aoc.Ems.Web.Controllers
{
    [Route("api/ems")]
    public class EmsApiController : Controller
    {
        EmsDbContext _emsDbContext;

        public EmsApiController(EmsDbContext emsDbContext) =>
            _emsDbContext = emsDbContext;

        [HttpPost("userlevel")]
        public async Task<JsonResult> CreateUserLevelAsync([FromBody] UserLevel userLevel)
        {
            if (userLevel == null) return new JsonResult(false);

            _emsDbContext.UserLevels.Add(userLevel);
            return new JsonResult((await _emsDbContext.SaveChangesAsync()) > 0);
        }
        [HttpGet("userlevel/{id}")]
        public async Task<JsonResult> ReadUserLevelAsync(String id = null) =>
            new JsonResult(await (id == null ?
                _emsDbContext.UserLevels :
                _emsDbContext.UserLevels.Where(ul =>
                    ul.Id == Convert.ToInt32(id))).ToListAsync());
        [HttpPost("userlevel")]
        public async Task<JsonResult> UpdateUserLevelAsync([FromBody] UserLevel userLevel)
        {
            if (userLevel == null |
                await _emsDbContext.UserLevels.FirstOrDefaultAsync(ul => ul.Id == userLevel.Id) == null)
                return new JsonResult(false);

            _emsDbContext.UserLevels.Update(userLevel);
            return new JsonResult((await _emsDbContext.SaveChangesAsync()) > 0);
        }
        [HttpDelete("userlevel/{id}")]
        public async Task<JsonResult> DeleteUserLevelAsync(String id = null)
        {
            var userLevel = id == null ? 
                null : 
                _emsDbContext.UserLevels.FirstOrDefaultAsync(ul => ul.Id == Convert.ToInt32(id));
            if (userLevel == null) return new JsonResult(false);

            _emsDbContext.Remove(userLevel);
            return new JsonResult((await _emsDbContext.SaveChangesAsync()) > 0);
        }
    }
}