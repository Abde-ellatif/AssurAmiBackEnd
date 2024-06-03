using AssurAmiBackEnd.Core.Entity;

namespace AssurAmiBackEnd.Core.Services
{
    public interface IClient
    {
        Task LoadDataClient(string filepath);
        Task UploadFile(IFormFile file);
        Task<IEnumerable<Client>> GetAllClientsAsync();
    }
}
