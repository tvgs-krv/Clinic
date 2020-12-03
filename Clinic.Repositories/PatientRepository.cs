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
using Npgsql;

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
            PatientEntity entity = patient.ToEntity();
            CreatePatientPosition(entity);
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

            dt.Rows.Add(
                patientEntity.Id,
                patientEntity.CreatedDate,
                patientEntity.SoftDeletedDate,
                patientEntity.FirstName,
                patientEntity.MiddleName,
                patientEntity.LastName,
                patientEntity.Age,
                patientEntity.Gender,
                patientEntity.IsDeleted);

            UpdateDataInDb(dt);
        }


        public string CreatePatientTable()
        {
            var connectionString = $"CREATE TABLE if not exists {TableName} (" +
                                   $"Id INTEGER CONSTRAINT Id PRIMARY KEY," +
                                   $"CreatedDate DATE," +
                                   $"SoftDeletedDate DATE," +
                                   $"FirstName VARCHAR(30)," +
                                   $"MiddleName VARCHAR(30)," +
                                   $"LastName VARCHAR(30)," +
                                   $"Age INTEGER," +
                                   $"Gender VARCHAR(8)," +
                                   $"IsDeleted BOOLEAN" +
                                   $")";

            return CreateEntity(connectionString);
        }

        public void CreatePatientPosition(PatientEntity patientEntity)
        {
            try
            {
                string softDeleteDate;
                var softDel = patientEntity.SoftDeletedDate;
                
                if (softDel != null)
                    softDeleteDate = "'" + softDel.Value.ToString("yyyy-MM-dd") + "'";
                else
                    softDeleteDate = "NULL";

                var insert = $"INSERT INTO {TableName} VALUES (" +
                             $"{patientEntity.Id}," +
                             $"'{patientEntity.CreatedDate}'," +
                             $"{softDeleteDate}," +
                             $"'{patientEntity.FirstName}'," +
                             $"'{patientEntity.MiddleName}'," +
                             $"'{patientEntity.LastName}'," +
                             $"'{patientEntity.Age}'," +
                             $"'{patientEntity.Gender}'," +
                             $"{patientEntity.IsDeleted}" +
                             $") ON CONFLICT (id) DO NOTHING";
                
                CreateEntity(insert);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


    }
}
