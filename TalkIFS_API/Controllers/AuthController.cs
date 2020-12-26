using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TalkIFS_API.Helpers;

namespace TalkIFS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var loginContent = _repo.Login(_config["BaseIfsUrl"],userForLoginDto.Username, userForLoginDto.Password);
            Secrets.CurrentAuthInfo = loginContent;


            return Ok(loginContent);
        }
    }
}
