using System.ComponentModel.DataAnnotations;
using Clinic.Domains;
namespace Clinic.Validation.ValidationAttribute
{
    
    class PatientValidationAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("Пациент не найден");

            var patient = value as Patient;
            var clinicInfomation = new ClinicInformation();

            if (patient?.Age < 1 || patient?.Age > 120) 
                return new ValidationResult("Возраст пациента не корректный");
            if (patient?.FirstName.Length < 1 || patient?.FirstName.Length > 30) 
                return new ValidationResult("Имя пациента не корректно");
            if (patient?.MiddleName?.Length < 1 || patient?.MiddleName?.Length > 30) 
                return new ValidationResult("Отчество пациента не корректно");
            if (patient?.LastName.Length < 1 || patient?.LastName.Length > 30) 
                return new ValidationResult("Фамилия пациента не корректна");
            if (patient?.CreatedDate < clinicInfomation.ClinicOpeningDate) 
                return new ValidationResult("Дата создания карточки пациента не корректа");

            return ValidationResult.Success;

        }
    }
}
