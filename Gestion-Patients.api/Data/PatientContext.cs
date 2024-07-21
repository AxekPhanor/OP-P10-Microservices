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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>()
                .HasMany(g => g.Patients)
                .WithOne(g => g.Address);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Address)
                .WithMany(a => a.Patients)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey(p => p.AddressId);
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
