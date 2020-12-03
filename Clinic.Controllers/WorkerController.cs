using Clinic.Domains;
using Clinic.Mappers;
using Clinic.Models;
using Clinic.Services;

namespace Clinic.Controllers
{
    public class WorkerController
    {
        private readonly WorkersService _workersService;

        public WorkerController(WorkersService workersService)
        {
            _workersService = workersService;
        }

        public void Create(WorkerModel workerModel)
        {
            _workersService.Create(workerModel);
        }

        public WorkerModel Get(int id)
        {
            Worker worker = _workersService.Get(id);
            return worker.ToModel();
        }

        public WorkerModel Update(WorkerModel workerModel)
        {
            var worker = _workersService.Update(workerModel);
            return worker.ToModel();
        }

        public void Delete(int id)
        {
            _workersService.Delete(id);
        }


    }
}
