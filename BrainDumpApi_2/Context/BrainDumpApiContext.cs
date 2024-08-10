using BrainDumpApi_2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrainDumpApi_2.Context
{
    public class BrainDumpApiContext : IdentityDbContext<ApplicationUser>
    {
        public BrainDumpApiContext(DbContextOptions<BrainDumpApiContext> options) : base(options) 
        {
            
        }

        public DbSet<Nota> Notas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
