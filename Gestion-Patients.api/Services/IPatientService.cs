using Gestion_Patients.api.Models;

namespace Gestion_Patients.api.Services
{
    public interface IPatientService
    {
        Task<PatientOutputModel> Create(PatientIntputModel patientModel);
        Task<PatientOutputModel?> GetById(int id);
        Task<PatientOutputModel?> Update(PatientIntputModel patientModel, int id);
        Task<PatientOutputModel?> Delete(int id);
        Task<List<PatientOutputModel>> All();
    }
}
