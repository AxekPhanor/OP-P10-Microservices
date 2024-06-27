using Gestion_Patients.api.Data.Entities;

namespace Gestion_Patients.api.Repositories
{
    public interface IGenderRepository
    {
        Task<Gender> Create(Gender gender);
        Task<Gender?> Read(int id);
        Task<Gender?> Read(string name);
        Task<Gender?> Update(Gender gender);
        Task<Gender?> Delete(int id);
    }
}
