using AssurAmiBackEnd.Core.Entity.Authentification;
using AssurAmiBackEnd.Infrastructure.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AssurAmiBackEnd.Core.Services
{
    public class UsersImplementation:IUsers
    {
        
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersImplementation(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        //desactiver un compte
        public async Task<(bool Success, string Message)> disabledAccount(string userId)
        {
            // Rechercher l'utilisateur par son ID
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return (false, "Utilisateur introuvable");
            }

            if (!user.ActivateCompte)
            {
                return (false, "Le compte est déjà désactivé");
            }

            // Activer le compte
            user.ActivateCompte = false;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return (true, "Le compte a été désactivé avec succès");
            }
            else
            {
                return (false, "Erreur lors de désactivation du compte");
            }

        }
        //activer un compte
        public async Task<(bool Success, string Message)> enableAccount(string userId)
        {
            // Rechercher l'utilisateur par son ID
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return (false, "Utilisateur introuvable");
            }

            if (user.ActivateCompte)
            {
                return (false, "Le compte est déjà activé");
            }

            // Activer le compte
            user.ActivateCompte = true;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return (true, "Le compte a été activé avec succès");
            }
            else
            {
                return (false, "Erreur lors de l'activation du compte");
            }
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
