using Clinic.Domains;
using Clinic.Mappers;
using Clinic.Repositories;
using Clinic.ServiceContracts;

namespace Clinic.Services
{
    public class PatientsService : IPersonService<Patient>
    {
        private readonly PatientRepository _patientRepository;


        public Patient Add(Patient person)
        {
            _patientRepository.Add(person.ToEntity());
            return person;
        }

        public void Update(Patient person)
        {
            throw new System.NotImplementedException();
        }

        public Patient Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            _patientRepository.Delete(id);
        }

        public PatientsService()
        {
            _patientRepository = new PatientRepository();
        }

    }
}
