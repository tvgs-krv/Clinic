using System;

namespace Clinic.Entities.Abstract
{
    interface IWorkerEntity
    {
        Position Position { get; set; }
        DateTime EmploymentDateTime { get; set; }
        DateTime TakingOfficeDate { get; set; }
        string Description { get; set; }

    }
}
