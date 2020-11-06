using Clinic.Domains;
using Clinic.Mappers;
using Clinic.Models;
using Clinic.Services;

namespace Clinic.Controllers
{
    public class PatientController
    {
        private readonly PatientsService _patientsService;
        public PatientController(PatientsService patientsService)
        {
            _patientsService = patientsService;
        }

        public void Create(PatientModel patientModel)
        {
            _patientsService.Create(patientModel);
        }

        public PatientModel Get(int id)
        {
            Patient patient = _patientsService.Get(id);
            return patient.ToModel();
        }
        public PatientModel Update(PatientModel patientModel)
        {
            var patient = _patientsService.Update(patientModel);
            return patient.ToModel();
        }

        public void Delete(int id)
        {
            _patientsService.Delete(id);
        }


    }
}
