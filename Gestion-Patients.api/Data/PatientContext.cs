using Gestion_Patients.api.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Patients.api.Data
{
    public class PatientContext : IdentityDbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>()
                .HasIndex(g => g.Name)
                .IsUnique();

            modelBuilder.Entity<Gender>()
                .HasMany(g => g.Patients)
                .WithOne(g => g.Gender)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Address>()
                .HasIndex(address => address.Name)
                .IsUnique();

            modelBuilder.Entity<Address>()
                .HasMany(g => g.Patients)
                .WithOne(g => g.Address)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Gender)
                .WithMany(g => g.Patients)
                .HasForeignKey(p => p.GenderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Address)
                .WithMany(a => a.Patients)
                .HasForeignKey(p => p.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
