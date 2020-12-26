using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using TalkIFS_API.Helpers;

namespace TalkIFS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAttendanceController : ControllerBase
    {
        private readonly IProjectAttendanceRepository _repo;
        private readonly IConfiguration _config;

        public ProjectAttendanceController(IProjectAttendanceRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpGet("{inducteeName?}")]
        public async Task<IActionResult> GetAttendances(string inducteeName = null)
        {
            var attendances = _repo.GetAttendancesAsync(_config["BaseUrl"], Secrets.CurrentAuthInfo.access_token, inducteeName).Result;
            return Ok(attendances);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttendance(ProjectAttendance projectAttendance)
        {
            
            var attendance = _repo.CreateAttendanceAsync(_config["BaseUrl"], Secrets.CurrentAuthInfo.access_token, projectAttendance).Result;
            return Ok(attendance);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAttendance(ProjectAttendance projectAttendance)
        {

            var attendance = _repo.UpdateAttendanceAsync(_config["BaseUrl"], Secrets.CurrentAuthInfo.access_token, projectAttendance).Result;
            return Ok(attendance);
        }

        //[HttpGet("{inducteeName}")]
        //public async Task<IActionResult> GetAttendancesByInductee(string inducteeName)
        //{
        //    var attendance = _repo.GetAttendenceByInducteeAsync(_config["BaseUrl"], inducteeName, Secrets.CurrentAuthInfo.access_token).Result;
        //    return Ok(attendance);
        //}
    }
}
