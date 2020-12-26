using lab5.Data.Configurations;
using lab5.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace lab5.Data
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CarPurchase> Purchases { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public override int SaveChanges()
        {
            var entries = this.ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var entity = entry.Entity;
                var validationContext = new ValidationContext(entity);

                Validator.ValidateObject(entity, validationContext, true);
            }   

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(DataSettings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this.GetType().Assembly OR 

            //var types = Assembly
            //    .GetExecutingAssembly()
            //    .GetExportedTypes()
            //    .Where(t => t.GetInterfaces().Any(i => i.IsInterface && i.IsGenericType && i.GetType().GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
            //    .ToList();

            //=> modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.ApplyConfiguration(new MakeConfiguration());

            modelBuilder.Entity<Car>(car =>
            {
                car
                    .HasIndex(c => c.Vin)
                    .IsUnique();

                car
                    .HasOne(m => m.Model)
                    .WithMany(c => c.Cars)
                    .HasForeignKey(m => m.ModelId)
                    .OnDelete(DeleteBehavior.Restrict);

                car.Property<int>("MySecretProperty");
            });

            modelBuilder.Entity<CarPurchase>(purchase =>
            {
                purchase.HasKey(p => new {p.CustomerId, p.CarId});

                purchase
                    .HasOne(p => p.Customer)
                    .WithMany(c => c.Purchases)
                    .HasForeignKey(p => p.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                purchase
                    .HasOne(p => p.Car)
                    .WithMany(c => c.Owners)
                    .HasForeignKey(p => p.CarId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Customer>(customer =>
            {
                customer
                    .HasOne(c => c.Address)
                    .WithOne(a => a.Customer)
                    .HasForeignKey<Address>(a => a.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
