namespace PetClinic.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetClinic.Models;

    public class PetClinicContext : DbContext
    {
        public PetClinicContext() { }

        public PetClinicContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Passport> Passports { get; set; }

        public DbSet<Vet> Vets { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<AnimalAid> AnimalAids { get; set; }

        public DbSet<ProcedureAnimalAid> ProceduresAnimalAids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vet>(vet => 
            {
                vet
                    .HasIndex(v => v.PhoneNumber)
                    .IsUnique();
            });

            builder.Entity<AnimalAid>(animalAid =>
            {
                animalAid
                    .HasIndex(v => v.Name)
                    .IsUnique();
            });

            builder.Entity<ProcedureAnimalAid>(procedureAnimalAid =>
            {
                procedureAnimalAid.HasKey(paa => new
                {
                    paa.ProcedureId,
                    paa.AnimalAidId
                });

                //officerPrisoner
                //    .HasOne(op => op.Prisoner)
                //    .WithMany(p => p.PrisonerOfficers)
                //    .HasForeignKey(op => op.PrisonerId)
                //    .OnDelete(DeleteBehavior.Restrict);

                //officerPrisoner
                //    .HasOne(op => op.Officer)
                //    .WithMany(o => o.OfficerPrisoners)
                //    .HasForeignKey(op => op.OfficerId)
                //    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
