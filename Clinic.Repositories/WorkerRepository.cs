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
    public class WorkerRepository : BaseRepository
    {
        public WorkerRepository()
        {
            TableName = "Workers";
        }

        public void Create(Worker worker)
        {
            var workerEntity = worker.ToEntity();
            CreateEntityInDb(workerEntity);
        }

        public WorkerEntity Get(int id)
        {
            if (IsExist(id))
            {
                DataTable data = GetDataFromDb(id);
                var getGender = data.Rows[0].Field<string>("gender");
                var gender = (Gender)Enum.Parse(typeof(Gender), getGender);

                var getPosition = data.Rows[0].Field<string>("position");
                var position = (Position)Enum.Parse(typeof(Position), getPosition);

                return new WorkerEntity
                {
                    Id = data.Rows[0].Field<int>("id"),
                    CreatedDate = data.Rows[0].Field<DateTime>("createddate"),
                    SoftDeletedDate = data.Rows[0].Field<DateTime?>("softdeleteddate"),
                    FirstName = data.Rows[0].Field<string>("firstname"),
                    MiddleName = data.Rows[0].Field<string>("middlename"),
                    LastName = data.Rows[0].Field<string>("lastname"),
                    Age = data.Rows[0].Field<int>("age"),
                    Gender = gender,
                    IsDeleted = data.Rows[0].Field<bool>("isdeleted"),
                    Description = data.Rows[0].Field<string>("description"),
                    Position = position,
                    HiringDateTime = data.Rows[0].Field<DateTime>("hiringDateTime"),
                    StartingWorkDate = data.Rows[0].Field<DateTime>("startingWorkDate")
                };

            }
            return new WorkerEntity();
        }

        public void Update(Worker worker)
        {
            var workerEntity = worker.ToEntity();
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
            dt.Columns.Add("description", typeof(string));
            dt.Columns.Add("hiringDateTime", typeof(DateTime));
            dt.Columns.Add("startingWorkDate", typeof(DateTime));
            dt.Columns.Add("position", typeof(string));
            dt.Rows.Add(
                workerEntity.Id, 
                workerEntity.CreatedDate,
                workerEntity.SoftDeletedDate, 
                workerEntity.FirstName, 
                workerEntity.MiddleName,
                workerEntity.LastName, 
                workerEntity.Age, 
                workerEntity.Gender, 
                workerEntity.IsDeleted,
                workerEntity.Description,
                workerEntity.HiringDateTime,
                workerEntity.StartingWorkDate,
                workerEntity.Position
            );
            UpdateDataInDb(dt);

        }

    }
}
