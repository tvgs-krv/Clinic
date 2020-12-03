using System.ComponentModel.DataAnnotations;
using Clinic.Validation.Abstraction;

namespace Clinic.Validation.ValidationAttribute
{
    public class WorkerValidationAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null) return new ValidationResult("Сотрудник не найден");

            var worker = value as IWorkerModel;

            if (worker?.Age < 1 || worker?.Age > 120) 
                return new ValidationResult("Возраст работника не корректный");
            if (worker?.FirstName.Length < 1 || worker?.FirstName.Length > 30) 
                return new ValidationResult("Имя работника не корректно");
            if (worker?.MiddleName?.Length < 1 || worker?.MiddleName?.Length > 30) 
                return new ValidationResult("Отчество работника не корректно");
            if (worker?.LastName.Length < 1 || worker?.LastName.Length > 30) 
                return new ValidationResult("Фамилия работника не корректна");
            if (worker?.Description.Length < 1 || worker?.Description.Length > 600) 
                return new ValidationResult("Описание должно быть не менее 1 и не более 600 символов");
            return ValidationResult.Success;

        }
    }
}
