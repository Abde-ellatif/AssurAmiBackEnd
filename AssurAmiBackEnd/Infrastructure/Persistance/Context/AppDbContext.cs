using AssurAmiBackEnd.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace AssurAmiBackEnd.Infrastructure.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Assureur> Assureurs { get; set; }
        public DbSet<Gestionnaire> Gestionnaires { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Erreur> Erreurs { get; set; }
        public DbSet<FileStatus> FileStatuses { get; set; }
        


    }
}
