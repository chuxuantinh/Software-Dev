﻿namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>()
                .HasKey(userTrip => new { userTrip.UserId, userTrip.TripId });

            //modelBuilder.Entity<UserTrip>()
            //    .HasOne(ut => ut.User)
            //    .WithMany(u => u.UserTrips)
            //    .HasForeignKey(ut => ut.UserId);

            //modelBuilder.Entity<UserTrip>()
            //    .HasOne(ut => ut.Trip)
            //    .WithMany(t => t.UserTrips)
            //    .HasForeignKey(ut => ut.TripId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
