using System;
using Clinic.Entities;
using Clinic.Validation.Abstraction;
using Clinic.Validation.ValidationAttribute;

namespace Clinic.Models
{
    public class PatientModel : IPatientModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SoftDeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

    }
}
