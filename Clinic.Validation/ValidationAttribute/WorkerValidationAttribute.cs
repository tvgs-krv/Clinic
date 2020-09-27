using System.ComponentModel.DataAnnotations;
using Clinic.Domains;
namespace Clinic.Validation.ValidationAttribute
{
    class WorkerValidationAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("Сотрудник не найден");

            var worker = value as Worker;

            if (worker?.Age < 1 || worker?.Age > 120) 
                return new ValidationResult("Возраст пациента не корректный");
            if (worker?.FirstName.Length < 1 || worker?.FirstName.Length > 30) 
                return new ValidationResult("Имя пациента не корректно");
            if (worker?.MiddleName?.Length < 1 || worker?.MiddleName?.Length > 30) 
                return new ValidationResult("Отчество пациента не корректно");
            if (worker?.LastName.Length < 1 || worker?.LastName.Length > 30) 
                return new ValidationResult("Фамилия пациента не корректна");
            if (worker?.Description.Length < 1 || worker?.Description.Length > 600) 
                return new ValidationResult("Описание должно быть не менее 1 и не более 600 символов");
            return ValidationResult.Success;

        }
    }
}
