using AssurAmiBackEnd.Core.Entity.Authentification;

namespace AssurAmiBackEnd.Core.Services
{
    public interface IUsers
    {
        Task<(IEnumerable<ApplicationUser> applicationUsers, int totalCount)> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<(bool Success, string Message)> disabledAccount(string userId);
        Task<(bool Success, string Message)> enableAccount(string userId);
        Task<(bool Success, string Message)> updatePassword(ApplicationUser applicationUser);
    }
}
