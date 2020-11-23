using CMS.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Chief> Chiefs { get; set; }

        public DbSet<House> Houses { get; set; }

        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().ToTable("Admin");

            modelBuilder.Entity<Chief>().ToTable("Chief");

            modelBuilder.Entity<House>().ToTable("House");

            modelBuilder.Entity<Region>().ToTable("Region");
        }
    }
}