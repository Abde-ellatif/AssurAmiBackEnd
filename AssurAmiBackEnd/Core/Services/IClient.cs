using AssurAmiBackEnd.Core.Entity;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssurAmiBackEnd.Core.Services
{
    public interface IClient
    {
        Task LoadDataClient(string filepath);
        Task UploadFile(IFormFile file);
        Task<(IEnumerable<Client> Clients, int TotalCount)> GetAllClientsAsync(int pageNumber, int pageSize);
    }
}
