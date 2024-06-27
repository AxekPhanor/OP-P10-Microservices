using Gestion_Patients.api.Data;
using Gestion_Patients.api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Patients.api.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly PatientContext dbContext;
        public AddressRepository(PatientContext dbContext) 
        { 
            this.dbContext = dbContext;
        }

        public async Task<Address> Create(Address address)
        {
            try
            {
                var existingAddress = await dbContext.Addresses.FirstOrDefaultAsync(a => a.Name == address.Name);
                if (existingAddress is null)
                {
                    await dbContext.Addresses.AddAsync(address);
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    address = existingAddress;
                }
                return address;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Address?> Delete(int id)
        {
            try
            {
                var address = await dbContext.Addresses.FirstOrDefaultAsync(address => address.Id == id);
                if (address is not null)
                {
                    dbContext.Addresses.Remove(address);
                    await dbContext.SaveChangesAsync();
                }
                return address;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Address?> Read(int id)
        {
            try
            {
                var address = await dbContext.Addresses.FirstOrDefaultAsync(address => address.Id == id);
                return address;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Address?> Read(string name)
        {
            try
            {
                var address = await dbContext.Addresses.FirstOrDefaultAsync(address => address.Name == name);
                return address;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Address?> Update(Address address)
        {
            try
            {
                var addressToUpdate = await dbContext.Addresses.FirstOrDefaultAsync(p => p.Id == address.Id);
                if (addressToUpdate is not null)
                {
                    addressToUpdate.Name = address.Name;
                    await dbContext.SaveChangesAsync();
                }
                return addressToUpdate;
            }
            catch
            {
                throw;
            }
        }
    }
}
