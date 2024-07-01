using AssurAmiBackEnd.Core.Entity.Authentification;
using AssurAmiBackEnd.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace AssurAmiBackEnd.Core.Services
{
    public class UsersImplementation:IUsers
    {
        private readonly AppDbContext _context;
        public UsersImplementation(AppDbContext context)
        {
            _context = context;
        }
        //desactiver un compte
        public async Task<(bool Success, string Message)> disabledAccount(ApplicationUser applicationUser)
        {
            if (applicationUser.ActivateCompte != false)
            {
                applicationUser.ActivateCompte = false;
                await _context.SaveChangesAsync();
                return (true, "le compte a ete desactive");
            }
            else
                return (false, "erreur lors de desactivation de compte ");
            
        }
        //activer un compte
        public async Task<(bool Success, string Message)> enableAccount(ApplicationUser applicationUser)
        {
            if (applicationUser.ActivateCompte != true)
            {
                applicationUser.ActivateCompte = true;
                await _context.SaveChangesAsync();
                return (true, "le compte a ete activer avec succées");
            }
            else
                return (false, "erreur lors d'activation de compte ");
        }

        public async Task<(IEnumerable<ApplicationUser> applicationUsers, int totalCount)> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            var totalUsers = await _context.ApplicationUsers.CountAsync();
            var users = await _context.ApplicationUsers
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (users, totalUsers);
        }
        public async Task<(bool Success, string Message)> updatePassword(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }
    }
}
