using Clinic.Domains;
using Clinic.Entities;
using Clinic.Models;

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

        public static Patient ToDomain(this PatientEntity patientEntity)
        {
            return new Patient
            {
                Id = patientEntity.Id,
                FirstName = patientEntity.FirstName,
                MiddleName = patientEntity.MiddleName,
                LastName = patientEntity.LastName,
                Age = patientEntity.Age,
                CreatedDate = patientEntity.CreatedDate,
                Gender = patientEntity.Gender,
                IsDeleted = patientEntity.IsDeleted,
                SoftDeletedDate = patientEntity.SoftDeletedDate
            };
        }

        public static Patient ToDomain(this PatientModel patientModel)
        {
            return new Patient
            {
                Id = patientModel.Id,
                FirstName = patientModel.FirstName,
                MiddleName = patientModel.MiddleName,
                LastName = patientModel.LastName,
                Age = patientModel.Age,
                CreatedDate = patientModel.CreatedDate,
                Gender = patientModel.Gender,
                IsDeleted = patientModel.IsDeleted,
                SoftDeletedDate = patientModel.SoftDeletedDate
            };
        }
        
        public static PatientModel ToModel(this Patient patient)
        {
            return new PatientModel
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
