using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;

namespace TalkIFS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectInducteeController : ControllerBase
    {
        private readonly IProjectInducteeRepository _repo;

        public ProjectInducteeController(IProjectInducteeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetInductees()
        {
            var inductees=  _repo.GetInducteesAsync();
            return Ok(inductees.Result);
        }
    }
}
