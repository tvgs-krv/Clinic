using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domains;
using Clinic.Entities;
using Clinic.Mappers;
using Clinic.Repositories.Abstract;

namespace Clinic.Repositories
{
    public class PatientRepository : BaseRepository
    {
        public PatientRepository()
        {
            TableName = "Patients";
        }
        public void Create(Patient patient)
        {
            var entity = patient.ToEntity();
            CreateEntityInDb(entity);
        }

        public PatientEntity Get(int id)
        {

            if (IsExist(id))
            {
                DataTable getData = GetDataFromDb(id);
                var getGender = getData.Rows[0].Field<string>("gender");
                var gender = (Gender)Enum.Parse(typeof(Gender), getGender);
                return new PatientEntity
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
            return new PatientEntity();
        }

        public void Update(Patient patient)
        {
            var patientEntity = patient.ToEntity();
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
            dt.Rows.Add(patientEntity.Id, patientEntity.CreatedDate,
                patientEntity.SoftDeletedDate, patientEntity.FirstName, patientEntity.MiddleName,
                patientEntity.LastName, patientEntity.Age, patientEntity.Gender, patientEntity.IsDeleted);
            UpdateDataInDb(dt);
        }

    }
}
