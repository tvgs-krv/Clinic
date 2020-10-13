using Clinic.Domains;
using Clinic.Entities;

namespace Clinic.Mappers
{
    public static class PatientMapper
    {
        public static PatientEntity ToEntity(this Patient patient)
        {
            return new PatientEntity
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                MiddleName = patient.MiddleName,
                LastName = patient.LastName,
                Age = patient.Age,
                CreatedDate = patient.CreatedDate,
                Gender = patient.Gender,
                IsDeleted = patient.IsDeleted,
                SoftDeletedDate = patient.SoftDeletedDate

            };
        }

    }
}
