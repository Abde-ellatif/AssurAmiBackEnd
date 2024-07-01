using AssurAmiBackEnd.Core.Entity.Authentification;

namespace AssurAmiBackEnd.Core.Services
{
    public interface IUsers
    {
        Task<(IEnumerable<ApplicationUser> applicationUsers, int totalCount)> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<(bool Success, string Message)> disabledAccount(ApplicationUser applicationUser);
        Task<(bool Success, string Message)> enableAccount(ApplicationUser applicationUser);
        Task<(bool Success, string Message)> updatePassword(ApplicationUser applicationUser);
    }
}
