using Clinic.Domains;
using Clinic.Repositories;
using Clinic.ServiceContracts;

namespace Clinic.Services
{
    public class PatientsService : IPatientsService
    {
        private readonly PatientRepository _repo;

        public PatientsService()
        {
            _repo = new PatientRepository();
        }

        public Patient AddPatient(Patient patient)
        {
            _repo.Add(patient);
            return patient;
        }

        public void DeletePatient(int id)
        {
            _repo.Delete(id);
        }
    }
}
