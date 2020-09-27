using System;

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
