using Microsoft.AspNetCore.Mvc;
using sage.challenge.data.Cache;
using sage.challenge.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sage.challenge.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var result = await _userService.CreateUser(user);
            if (result.Success)
            {
                return Ok(result.Response);
            }

            return BadRequest(result.ErrorMessage);

        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsers();
            if (result.Success)
            {
                return Ok(result.Response);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var result = await _userService.GetUser(id);
            if (result.Success)
            {
                return Ok(result.Response);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteUser(id);
            if (result.Success)
            {
                return Ok(result.Response);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(User user)
        {
            var result = await _userService.UpdateUser(user);
            if (result.Success)
            {
                return Ok(result.Response);
            }

            return BadRequest(result.ErrorMessage);
        }
    }
}
