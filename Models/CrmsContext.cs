using System;
using Microsoft.EntityFrameworkCore;

namespace ClassManagementSystem.Models
{
    public class CrmsContext : DbContext
    {
        public CrmsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .Property<DateTime>("gmt_modified")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<School>()
                .Property<DateTime>("gmt_create")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<School>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
                .Property<DateTime>("gmt_modified")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<User>()
                .Property<DateTime>("gmt_create")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Email);

            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Number);

            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Phone);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UnionId)
                .IsUnique();
        }
    }
}