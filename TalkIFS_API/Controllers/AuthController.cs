using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkIFS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = _repo.Login(userForLoginDto.Username, userForLoginDto.Password);

            return Ok();
        }
    }
}
