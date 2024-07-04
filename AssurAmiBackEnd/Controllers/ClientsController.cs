using AssurAmiBackEnd.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssurAmiBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClient _clientService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ClientsController(IWebHostEnvironment webHostEnvironment, IClient clientService)
        {
            _clientService = clientService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> StoredUploadCsvFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "File is empty." });
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                {
                     return Unauthorized(new { message = "User ID not found" });
                }
            try
            {
                await _clientService.UploadFile(file, userId);
                var directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");
                var directoryPathSuccessed = Path.Combine(directoryPath, "SuccessedFile");
                Directory.CreateDirectory(directoryPathSuccessed);
                var filePath = Path.Combine(directoryPathSuccessed, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Ok(new { message = "uploaded successfully" });
            }

            catch (Exception ex)
            {
                var directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");
                var directoryPathFailed = Path.Combine(directoryPath, "FailedFile");
                Directory.CreateDirectory(directoryPathFailed);
                var filePath = Path.Combine(directoryPathFailed, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }



        }



        [HttpGet("get-clients")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetClients([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var (clients, totalCount) = await _clientService.GetAllClientsAsync(pageNumber, pageSize);
            return Ok(new { clients, totalCount });
        }
    }
}
