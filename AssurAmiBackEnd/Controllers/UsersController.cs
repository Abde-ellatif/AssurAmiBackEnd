using AssurAmiBackEnd.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssurAmiBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _iUsers;
        public UsersController(IUsers users) { 
            _iUsers = users;
        }

        [HttpGet("get-users")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUsers([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var (users, totalCount) = await _iUsers.GetAllUsersAsync(pageNumber, pageSize);
            return Ok(new { users, totalCount });
        }
    }
}
