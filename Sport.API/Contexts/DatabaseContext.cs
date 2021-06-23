using Microsoft.EntityFrameworkCore;
using Sport.API.Models;

namespace Sport.API.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

        public DbSet<Modality> Modalities { get; set; }
    }
}
