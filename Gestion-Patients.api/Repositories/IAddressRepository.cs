using Gestion_Patients.api.Data.Entities;

namespace Gestion_Patients.api.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> Create(Address address);
        Task<Address?> Read(int id);
        Task<Address?> Read(string name);
        Task<Address?> Update(Address address);
        Task<Address?> Delete(int id);
    }
}
