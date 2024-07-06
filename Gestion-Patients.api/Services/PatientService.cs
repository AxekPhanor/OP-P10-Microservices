using Gestion_Patients.api.Models;
using Gestion_Patients.api.Repositories;
using Gestion_Patients.api.Data.Entities;

namespace Gestion_Patients.api.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;
        private readonly IAddressRepository addressRepository;

        public PatientService(IPatientRepository patientRepository, IAddressRepository addressRepository)
        {
            this.patientRepository = patientRepository;
            this.addressRepository = addressRepository;
        }

        public async Task<PatientOutputModel> Create(PatientIntputModel patientModel)
        {
            try
            {
                var patient = await patientRepository.Create(await ToEntity(patientModel, 0));
                return ToOutputModel(patient);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PatientOutputModel?> Delete(int id)
        {
            try
            {
                var patient = await patientRepository.Delete(id);
                if (patient is null)
                {
                    return null;
                }
                return ToOutputModel(patient);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PatientOutputModel>> All()
        {
            try
            {
                var patients = await patientRepository.List();
                var output = new List<PatientOutputModel>();
                foreach (var patient in patients)
                {
                    output.Add(ToOutputModel(patient));
                }
                return output;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PatientOutputModel?> GetById(int id)
        {
            try
            {
                var patient = await patientRepository.Read(id);
                if(patient is not null)
                {
                    return ToOutputModel(patient);
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PatientOutputModel?> Update(PatientIntputModel patientModel, int id)
        {
            try
            {
                var patientUpdated = await patientRepository.Update(await ToEntity(patientModel, id));
                if(patientUpdated is not null)
                {
                    return ToOutputModel(patientUpdated);
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        private async Task<Patient> ToEntity(PatientIntputModel patientModel, int id)
        {
            var patient = new Patient()
            {
                Id = id,
                FirstName = patientModel.FirstName,
                LastName = patientModel.LastName,
                DateOfBirth = patientModel.DateOfBirth,
                Gender = patientModel.Gender,
            };

            if (patientModel.Address is not null)
            {
                var address = await addressRepository.Create(new Address { Name = patientModel.Address });
                patient.Address = address;
                patient.AddressId = address.Id;
            }

            if (patientModel.PhoneNumber is not null)
            {
                patient.PhoneNumber = patientModel.PhoneNumber;
            }
            return patient;
        }

        private PatientOutputModel ToOutputModel(Patient patient)
        {
            var output = new PatientOutputModel()
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
            };
            if (patient.Address is not null) 
            { 
                output.Address = patient.Address.Name;
            }
            if (patient.PhoneNumber is not null)
            {
                output.PhoneNumber = patient.PhoneNumber;
            }
            return output;
        }
    }
}
