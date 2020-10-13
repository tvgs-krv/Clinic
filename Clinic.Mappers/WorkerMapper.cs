using Clinic.Domains;
using Clinic.Entities;

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
                HiringDateTime = worker.EmploymentDateTime,
                Position = worker.Position,
                StartingWorkDate = worker.TakingOfficeDate

            };
        }
    }
}
