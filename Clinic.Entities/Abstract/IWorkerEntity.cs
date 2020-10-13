using System;

namespace Clinic.Entities.Abstract
{
    interface IWorkerEntity
    {
        Position Position { get; set; }
        DateTime HiringDateTime { get; set; }
        DateTime StartingWorkDate { get; set; }
        string Description { get; set; }

    }
}
