using GoodReads.Core.Books;
using GoodReads.Core.Users;
using GoodReads.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GoodReads.EntityFrameworkCore
{
    public class GoodReadsDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }

        public GoodReadsDbContext(DbContextOptions<GoodReadsDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserBookConfiguration());
        }
    }
}
