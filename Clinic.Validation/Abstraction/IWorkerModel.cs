using Clinic.Validation.ValidationAttribute;
using System;

namespace Clinic.Validation.Abstraction
{
    [WorkerValidation]
    public interface IWorkerModel
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? SoftDeletedDate { get; set; }
        bool IsDeleted { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        DateTime HiringDateTime { get; set; }
        DateTime StartingWorkDate { get; set; }
        string Description { get; set; }

    }
}
