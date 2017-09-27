using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Aoc.Ems.Core;
using Aoc.Ems.Data;

namespace Aoc.Ems.Web.Controllers
{
    [Route("api/ems")]
    public class EmsApiController : Controller
    {
        DbContext _emsDbContext;

        public EmsApiController(EmsDbContext emsDbContext) => _emsDbContext = emsDbContext;

        [HttpGet("{table}/{id}")]
        public async Task<JsonResult> LoadAsync(String table = null, String id = null) 
        {
            switch(table.ToLower())
            {
                case "applicant": return new JsonResult(await _emsDbContext.Set<Applicant>().ToListAsync());
                case "attendance": return new JsonResult(await _emsDbContext.Set<Attendance>().ToListAsync());
                case "employee": return new JsonResult(await _emsDbContext.Set<Employee>().ToListAsync());
                case "evaluation": return new JsonResult(await _emsDbContext.Set<Evaluation>().ToListAsync());
                case "examdate": return new JsonResult(await _emsDbContext.Set<ExamDate>().ToListAsync());
                case "examresult": return new JsonResult(await _emsDbContext.Set<ExamResult>().ToListAsync());
                case "interviewschedule": return new JsonResult(await _emsDbContext.Set<InterviewSchedule>().ToListAsync());
                case "registration": return new JsonResult(await _emsDbContext.Set<Registration>().ToListAsync());
                case "scheduleresult": return new JsonResult(await _emsDbContext.Set<ScheduleResult>().ToListAsync());
                case "user": return new JsonResult(await _emsDbContext.Set<User>().ToListAsync());
                case "userlevel": return new JsonResult(await _emsDbContext.Set<UserLevel>().ToListAsync());
                default: return new JsonResult(null);
            }
        }
    }
}