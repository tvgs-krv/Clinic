using Clinic.Domains;

namespace Clinic.ServiceContracts
{
    public interface IWorkersService
    {
        void AddWorker(Worker patient);
        void UpdateWorker(Worker patient);
        Worker GetWorker(int id);
        void DeleteWorker(int id);

    }
}
