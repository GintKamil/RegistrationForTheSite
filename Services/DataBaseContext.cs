using Microsoft.EntityFrameworkCore;
using RegistrationSite.Model;

namespace RegistrationSite.Services
{
    public class DataBaseContext : DbContext
    {
        public DbSet<RegistrationModel> Users { get; set; } = null!;
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistrationModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Email)
                      .IsUnique();
            });
        }
    }
}
