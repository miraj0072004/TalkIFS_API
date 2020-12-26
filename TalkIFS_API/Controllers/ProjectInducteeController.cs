using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using TalkIFS_API.Helpers;

namespace TalkIFS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectInducteeController : ControllerBase
    {
        private readonly IProjectInducteeRepository _repo;
        private readonly IConfiguration _config;

        public ProjectInducteeController(IProjectInducteeRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetInductees()
        {
            var inductees=  _repo.GetInducteesAsync(_config["BaseUrl"],Secrets.CurrentAuthInfo.access_token).Result;
            return Ok(inductees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInductee(string id)
        {
            var inductee = _repo.GetInducteesByIdAsync(_config["BaseUrl"], id,Secrets.CurrentAuthInfo.access_token ).Result;
            return Ok(inductee);
        }

        [HttpPost]
        public async Task<IActionResult> GetInductee(ProjectInductee inductee)
        {
            var inducteeCreated = _repo.CreateInductee(_config["BaseUrl"],inductee, Secrets.CurrentAuthInfo.access_token);
            return Ok(inducteeCreated);
        }


    }
}
