using System;
using Clinic.Entities.Abstract;

namespace Clinic.Entities
{
    public class VisitHistoryEntity : IVisitHistory
    {
        public int MedicalId { get; set; }
        public DateTime VisitDate { get; set; }
        public string ProceduresPerformed { get; set; }
        public string MedicationsUsed { get; set; }
    }
}
