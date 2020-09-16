using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
