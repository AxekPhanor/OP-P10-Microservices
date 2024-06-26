using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Patients.api.Data
{
    public class PatientContext : IdentityDbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options) { }
    }
}
