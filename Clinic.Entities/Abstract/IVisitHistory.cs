using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Entities.Abstract
{
    interface IVisitHistory
    {
        int MedicalId { get; set; }
        DateTime VisitDate { get; set; }
        string ProceduresPerformed { get; set; }
        string MedicationsUsed { get; set; }
    }
}
