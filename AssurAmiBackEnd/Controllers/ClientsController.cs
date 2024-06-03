
using AssurAmiBackEnd.Core.Entity;
using AssurAmiBackEnd.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssurAmiBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IClient _clientService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly string DefaultConnectionString = "Data Source=DESKTOP-MRMVJQJ\\SQLEXPRESS;Initial Catalog=Dbassurami;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public ClientsController(IWebHostEnvironment webHostEnvironment, IClient clientService)
        {
            _clientService = clientService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("/upload")]
        public async Task<IActionResult> StoredUploadCsvFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "File is empty." });

            try
            {
                await _clientService.UploadFile(file);
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


        [HttpGet("/get-clients")]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }
    }
}
