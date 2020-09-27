using Clinic.Entities.Abstract;

namespace Clinic.Entities
{
    public class PatientEntity : EntityBase, IPersonEntity
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
