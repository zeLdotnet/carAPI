using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarAPI.Models
{
    public partial class CarDbContext : DbContext
    {
        public CarDbContext()
        {
        }

        public CarDbContext(DbContextOptions<CarDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=CarDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(30);

                entity.Property(e => e.MYear).HasColumnName("mYear");

                entity.Property(e => e.Make).HasMaxLength(30);

                entity.Property(e => e.Model).HasMaxLength(30);
            });
        }
    }
}
