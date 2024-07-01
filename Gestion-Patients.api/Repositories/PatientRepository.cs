using Gestion_Patients.api.Data;
using Gestion_Patients.api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Patients.api.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientContext dbContext;
        public PatientRepository(PatientContext dbContext) 
        { 
            this.dbContext = dbContext;
        }

        public async Task<List<Patient>> List() 
        {
            return await dbContext.Patients
            .Include(p => p.Gender)
            .Include(p => p.Address)
            .ToListAsync();
        }

        public async Task<Patient> Create(Patient patient)
        {
            try
            {
                await dbContext.Patients.AddAsync(patient);
                await dbContext.SaveChangesAsync();
                return patient;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Patient?> Delete(int id)
        {
            try
            {
                var patient = await dbContext.Patients
                    .Include(p => p.Gender)
                    .Include(p => p.Address)
                    .FirstOrDefaultAsync(patient => patient.Id == id);
                if (patient is not null)
                {
                    dbContext.Patients.Remove(patient);
                    await dbContext.SaveChangesAsync();
                }
                return patient;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Patient?> Read(int id)
        {
            try
            {
                var patient = await dbContext.Patients
                    .Include(p => p.Gender)
                    .Include(p => p.Address)
                    .FirstOrDefaultAsync(patient => patient.Id == id);
                return patient;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Patient?> Update(Patient patient)
        {
            try
            {
                var patientToUpdate = await dbContext.Patients
                    .Include(p => p.Gender)
                    .Include(p => p.Address)
                    .FirstOrDefaultAsync(p => p.Id == patient.Id);
                if (patientToUpdate is not null)
                {
                    patientToUpdate.FirstName = patient.FirstName;
                    patientToUpdate.LastName = patient.LastName;
                    patientToUpdate.DateOfBirth = patient.DateOfBirth;
                    patientToUpdate.Gender = patient.Gender;
                    if (patientToUpdate.Address is not null)
                    {
                        patientToUpdate.Address = patient.Address;
                    }
                    if (patientToUpdate.PhoneNumber is not null)
                    {
                        patientToUpdate.PhoneNumber = patient.PhoneNumber;
                    }
                    await dbContext.SaveChangesAsync();
                }
                return patientToUpdate;
            }
            catch
            {
                throw;
            }
        }

        
    }
}
