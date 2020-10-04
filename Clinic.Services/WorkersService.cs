using Clinic.Domains;
using Clinic.Mappers;
using Clinic.Repositories;
using Clinic.ServiceContracts;

namespace Clinic.Services
{
    public class WorkersService : IPersonService<Worker>
    {
        private readonly WorkerRepository _workerRepository;

        public Worker Add(Worker worker)
        {
            //_workerRepository.AddPatient(worker.ToEntity());
            return worker;
        }

        public void Update(int id, Worker person)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Worker worker)
        {
            throw new System.NotImplementedException();
        }

        public Worker Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            _workerRepository.Delete(id);
        }

        public bool IsExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public WorkersService()
        {
            _workerRepository = new WorkerRepository();
        }

    }
}
