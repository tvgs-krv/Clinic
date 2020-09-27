using Clinic.Domains;

namespace Clinic.ServiceContracts
{
    public interface IPatientsService
    {
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        Patient GetPatient(int id);
        void DeletePatient(int id);
    }
}
