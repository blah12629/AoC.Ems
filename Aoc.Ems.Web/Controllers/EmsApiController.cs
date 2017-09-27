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
        DbContext _emsDbContext;

        public EmsApiController(EmsDbContext emsDbContext) =>
            _emsDbContext = emsDbContext;

        [HttpPost("{table}")]
        public async Task<JsonResult> Create([FromBody] Object entity = null)
        {
        }
    }
}