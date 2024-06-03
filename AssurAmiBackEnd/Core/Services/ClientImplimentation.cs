using AssurAmiBackEnd.Core.Entity;
using AssurAmiBackEnd.Infrastructure.Persistance.Context;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AssurAmiBackEnd.Core.Services
{
    public class ClientImplimentation:IClient
    {
        private readonly AppDbContext _context;
        public IConfiguration _configuration;
        private InputDateType _dateOnly;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly string DefaultConnectionString = "Data Source=DESKTOP-MRMVJQJ\\SQLEXPRESS;Initial Catalog=assuramii;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public ClientImplimentation(IConfiguration configuration, IWebHostEnvironment webHostEnvironment, AppDbContext context)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _context = context;

        }

        public async Task UploadFile(IFormFile file)
        {

            var directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");
            var directoryPathSuccessed = Path.Combine(directoryPath, "SuccessedFile");
            var directoryPathFialed = Path.Combine(directoryPath, "FailedFile");
            Directory.CreateDirectory(directoryPathSuccessed); // Create directory if it doesn't exist
            Directory.CreateDirectory(directoryPathFialed); // Create directory if it doesn't exist
            Console.WriteLine("le dossier est créer avec sucses");

            // Use the original file name for saving
            var filePath = Path.Combine(directoryPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            await this.LoadDataClient(filePath); // Await the asynchronous method






        }

        public async Task LoadDataClient(string filepath)
        {
            if (filepath != null)
            {

                //string connectionString = _configuration.GetConnectionString("connection");
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string storedProcedureName = "LoadCSVFile";
                    using (var command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FilePath", filepath);

                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("ok");
                    }
                }
            }


            else
            {
                throw new NotImplementedException();
            }

        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
