using Clinic.Domains;
using Clinic.Entities;
using Clinic.Models;

namespace Clinic.Mappers
{
    public static class WorkerMapper
    {
        public static WorkerEntity ToEntity(this Worker worker)
        {
            return new WorkerEntity
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                MiddleName = worker.MiddleName,
                LastName = worker.LastName,
                Age = worker.Age,
                CreatedDate = worker.CreatedDate,
                Gender = worker.Gender,
                IsDeleted = worker.IsDeleted,
                SoftDeletedDate = worker.SoftDeletedDate,
                Description = worker.Description,
                HiringDateTime = worker.HiringDateTime,
                Position = worker.Position,
                StartingWorkDate = worker.StartingWorkDate
            };
        }

        public static Worker ToDomain(this WorkerEntity workerEntity)
        {
            return new Worker
            {
                Id = workerEntity.Id,
                FirstName = workerEntity.FirstName,
                MiddleName = workerEntity.MiddleName,
                LastName = workerEntity.LastName,
                Age = workerEntity.Age,
                CreatedDate = workerEntity.CreatedDate,
                Gender = workerEntity.Gender,
                IsDeleted = workerEntity.IsDeleted,
                SoftDeletedDate = workerEntity.SoftDeletedDate,
                Description = workerEntity.Description,
                HiringDateTime = workerEntity.HiringDateTime,
                Position = workerEntity.Position,
                StartingWorkDate = workerEntity.StartingWorkDate

            };
        }

        public static Worker ToDomain(this WorkerModel workerModel)
        {
            return new Worker
            {
                Id = workerModel.Id,
                FirstName = workerModel.FirstName,
                MiddleName = workerModel.MiddleName,
                LastName = workerModel.LastName,
                Age = workerModel.Age,
                CreatedDate = workerModel.CreatedDate,
                Gender = workerModel.Gender,
                IsDeleted = workerModel.IsDeleted,
                SoftDeletedDate = workerModel.SoftDeletedDate,
                Description = workerModel.Description,
                HiringDateTime = workerModel.HiringDateTime,
                Position = workerModel.Position,
                StartingWorkDate = workerModel.StartingWorkDate

            };
        }


        public static WorkerModel ToModel(this Worker worker)
        {
            return new WorkerModel
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                MiddleName = worker.MiddleName,
                LastName = worker.LastName,
                Age = worker.Age,
                CreatedDate = worker.CreatedDate,
                Gender = worker.Gender,
                IsDeleted = worker.IsDeleted,
                SoftDeletedDate = worker.SoftDeletedDate,
                Description = worker.Description,
                HiringDateTime = worker.HiringDateTime,
                Position = worker.Position,
                StartingWorkDate = worker.StartingWorkDate

            };
        }


    }
}
