using Gestion_Patients.api.Data.Entities;

namespace Gestion_Patients.api.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> Create(Patient patient);
        Task<Patient?> Read(int id);
        Task<Patient?> Update(Patient patient);
        Task<Patient?> Delete(int id);
        Task<List<Patient>> List();
    }
}
