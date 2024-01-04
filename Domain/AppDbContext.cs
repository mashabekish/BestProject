using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.User)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.UserId);

            modelBuilder.Entity<Item>()
                .OwnsOne(i => i.Location, location =>
                {
                    location.Property(l => l.Latitude).HasColumnName("Latitude");
                    location.Property(l => l.Longitude).HasColumnName("Longitude");
                    location.Property(l => l.RadiusMeters).HasColumnName("RadiusMeters");
                });

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Image)
                .WithOne(img => img.Item)
                .HasForeignKey<Item>(i => i.ImageId);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
