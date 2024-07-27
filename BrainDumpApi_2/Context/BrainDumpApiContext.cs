using BrainDumpApi_2.Models;
using Microsoft.EntityFrameworkCore;

namespace BrainDumpApi_2.Context
{
    public class BrainDumpApiContext : DbContext
    {
        public BrainDumpApiContext(DbContextOptions<BrainDumpApiContext> options) : base(options) 
        {
            
        }

        public DbSet<Nota> Notas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
