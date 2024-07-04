using AssurAmiBackEnd.Core.Entity.Authentification;
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
        [HttpPatch("activer-compte")]
        public async Task<IActionResult> EnableCompte(string userId)
        {
            var result = await _iUsers.enableAccount(userId);

            if (result.Success)
            {
                return Ok(new { Success = true, Message = result.Message });
            }
            else
            {
                return BadRequest(new { Success = false, Message = result.Message });
            }
        }

        [HttpPatch("desactiver-compte")]
        public async Task<IActionResult> disabledAccount(string userId)
        {
            var result = await _iUsers.disabledAccount(userId);

            if (result.Success)
            {
                return Ok(new { Success = true, Message = result.Message });
            }
            else
            {
                return BadRequest(new { Success = false, Message = result.Message });
            }
        }

    }
}
