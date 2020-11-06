using Clinic.Domains;
using Clinic.Entities;
using Clinic.Mappers;
using Clinic.Models;
using Clinic.Repositories;
using Clinic.ServiceContracts;

namespace Clinic.Services
{
    public class WorkersService
    {
        private readonly WorkerRepository _workerRepository;

        public Worker Create(WorkerModel workerModel)
        {
            var worker = workerModel.ToDomain();
            _workerRepository.Create(worker);
            return worker;

        }

        public Worker Update(WorkerModel workerModel)
        {
            var worker = workerModel.ToDomain();
            _workerRepository.Update(worker);
            return worker;
        }

        public Worker Get(int id)
        {
            WorkerEntity workerEntity = _workerRepository.Get(id);
            return workerEntity.ToDomain();
        }

        public void Delete(int id)
        {
            _workerRepository.Delete(id);
        }

        public WorkersService(string connectionString)
        {
            _workerRepository = new WorkerRepository();
            _workerRepository.ConnectionString = connectionString;
            var currentConnection = _workerRepository.ConnectDb();
            _workerRepository.CreateTable(new Worker(), currentConnection);
        }

    }
}
