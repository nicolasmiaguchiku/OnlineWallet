using Microsoft.EntityFrameworkCore;
using OnlineWallet.Models;

namespace OnlineWallet.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id);
                u.Property(u => u.Name).HasMaxLength(50).IsRequired();
                u.Property(u => u.Email).HasMaxLength(128).IsRequired();
                u.Property(u => u.PasswordHash).HasMaxLength(128).IsRequired();
            });
        }
    }
}
