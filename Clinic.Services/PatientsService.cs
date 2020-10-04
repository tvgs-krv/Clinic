using System;
using System.Data;
using Clinic.Domains;
using Clinic.Entities;
using Clinic.Mappers;
using Clinic.Repositories;
using Clinic.ServiceContracts;

namespace Clinic.Services
{
    public class PatientsService : IPersonService<Patient>
    {
        private readonly PatientRepository _patientRepository;
        public Patient Add(Patient person)
        {
            var toEntity = person.ToEntity();
            _patientRepository.Add(toEntity);
            return person;
        }

        public void Update(Patient person)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("createddate", typeof(DateTime));
            dt.Columns.Add("softdeleteddate", typeof(DateTime));
            dt.Columns.Add("firstname", typeof(string));
            dt.Columns.Add("middlename", typeof(string));
            dt.Columns.Add("lastname", typeof(string));
            dt.Columns.Add("age", typeof(int));
            dt.Columns.Add("gender", typeof(string));
            dt.Columns.Add("isdeleted", typeof(bool));
            dt.Rows.Add(person.Id, person.CreatedDate, 
                person.SoftDeletedDate, person.FirstName,person.MiddleName, 
                person.LastName, person.Age, person.Gender, person.IsDeleted);
            _patientRepository.Update(dt);
        }

        public Patient Get(int id)
        {
            if (IsExist(id))
            {
                DataTable getData = _patientRepository.Get(id);
                var getGender = getData.Rows[0].Field<string>("gender");
                var gender = (Gender)Enum.Parse(typeof(Gender), getGender);
                return new Patient
                {
                    Id = getData.Rows[0].Field<int>("id"),
                    CreatedDate = getData.Rows[0].Field<DateTime>("createddate"),
                    SoftDeletedDate = getData.Rows[0].Field<DateTime?>("softdeleteddate"),
                    FirstName = getData.Rows[0].Field<string>("firstname"),
                    MiddleName = getData.Rows[0].Field<string>("middlename"),
                    LastName = getData.Rows[0].Field<string>("lastname"),
                    Age = getData.Rows[0].Field<int>("age"),
                    Gender = gender,
                    IsDeleted = getData.Rows[0].Field<bool>("isdeleted")
                };

            }
            return new Patient();
        }

        public void Delete(int id)
        {
            _patientRepository.Delete(id);
        }

        public bool IsExist(int id)
        {
            return _patientRepository.IsExist(id); ;
        }

        public PatientsService(string connectionString)
        {
            _patientRepository = new PatientRepository();
            _patientRepository.ConnectionString = connectionString;
            var currentConnection = _patientRepository.ConnectDb();
            _patientRepository.CreateTable(new Patient(), currentConnection);
        }

    }
}
