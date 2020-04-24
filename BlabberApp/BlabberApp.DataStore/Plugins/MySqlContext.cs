using BlabberApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlabberApp.DataStore.Plugins
{
    /// <summary>
    /// Added per Don's instructions, Thanks Don!
    /// </summary>
    public class MySqlContext : DbContext
    {
        /// <summary>
        /// Probably The Blab table
        /// </summary>
        public DbSet<Blab> Blab { get; set; }
        /// <summary>
        /// Probably the User table
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Configre SQL context
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionsBuilder object</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=142.93.114;database=R10NGW;user=R10NGW;password=letmein");
        }
        /// <summary>
        /// OnModelCreating I think this builds the User and Blab Tables?
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.LastLoginDTTM).IsRequired();
                entity.Property(e => e.RegisterDTTM).IsRequired();
            });

            modelBuilder.Entity<Blab>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DTTM).IsRequired();
                entity.Property(e => e.Message);
                entity.HasOne(u => u.User);
            });
        }
    }
}
