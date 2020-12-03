using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Entities;
using Clinic.Validation.ValidationAttribute;

namespace Clinic.Validation.Abstraction
{
    [PatientValidation]
    public interface IPatientModel
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? SoftDeletedDate { get; set; }
        bool IsDeleted { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        Gender Gender { get; set; }
    }
}
