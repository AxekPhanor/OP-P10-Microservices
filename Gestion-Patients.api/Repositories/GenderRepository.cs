using Gestion_Patients.api.Data;
using Gestion_Patients.api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Gestion_Patients.api.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly PatientContext dbContext;
        public GenderRepository(PatientContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Gender> Create(Gender gender)
        {
            try
            {
                var existingGender = await dbContext.Genders.FirstOrDefaultAsync(a => a.Name == gender.Name);
                if (existingGender is null)
                {
                    await dbContext.Genders.AddAsync(gender);
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    gender = existingGender;
                }
                return gender;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Gender?> Delete(int id)
        {
            try
            {
                var gender = await dbContext.Genders.FirstOrDefaultAsync(gender => gender.Id == id);
                if (gender is not null)
                {
                    dbContext.Genders.Remove(gender);
                    await dbContext.SaveChangesAsync();
                }
                return gender;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Gender?> Read(int id)
        {
            try
            {
                var gender = await dbContext.Genders.FirstOrDefaultAsync(gender => gender.Id == id);
                return gender;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Gender?> Read(string name)
        {
            try
            {
                var gender = await dbContext.Genders.FirstOrDefaultAsync(gender => gender.Name == name);
                return gender;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Gender?> Update(Gender gender)
        {
            try
            {
                var genderToUpdate = await dbContext.Genders.FirstOrDefaultAsync(p => p.Id == gender.Id);
                if (genderToUpdate is not null)
                {
                    genderToUpdate.Name = gender.Name;
                    await dbContext.SaveChangesAsync();
                }
                return genderToUpdate;
            }
            catch
            {
                throw;
            }
        }
    }
}
