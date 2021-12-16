using Microsoft.AspNetCore.Mvc;
using sage.challenge.data.Cache;
using sage.challenge.data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sage.challenge.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly ISimpleObjectCache<Guid, User> _cache;

        public UserController(ISimpleObjectCache<Guid, User> cache)
        {
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _cache.AddAsync(user.Id, user);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _cache.GetAllAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _cache.GetAsync(id);
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _cache.DeleteAsync(id);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(User user)
        {
            await _cache.UpdateAsync(user.Id, user);
            return Ok(user);
        }
    }
}
