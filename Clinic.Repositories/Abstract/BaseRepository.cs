using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domains;
using Npgsql;

namespace Clinic.Repositories.Abstract
{
    public class BaseRepository : IRepository
    {
        public string TableName { get; set; }
        public NpgsqlConnection ConnectDb()
        {
            string connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=123456789";
            return new NpgsqlConnection(connectionString);
        }

        public string CreateTable<T>(T tableColumns, NpgsqlConnection connection)
        {
            if (string.IsNullOrEmpty(TableName))
                throw new ArgumentNullException(nameof(TableName));
            if (tableColumns == null)
                throw new ArgumentNullException(nameof(tableColumns));
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            string connectionString = String.Empty;

            if (tableColumns is Patient)
                connectionString = $"CREATE TABLE if not exists {TableName}(" +
                                   $"Id CHAR(256) CONSTRAINT Id PRIMARY KEY," +
                                   $"CreatedDate DATE," +
                                   $"SoftDeletedDate DATE," +
                                   $"FirstName VARCHAR(30)," +
                                   $"MiddleName VARCHAR(30)," +
                                   $"LastName VARCHAR(30)," +
                                   $"Age INTEGER(120)," +
                                   $"Gender VARCHAR(8)," +
                                   $"IsDeleted BOOLEAN," +
                                   $")";
            if (tableColumns is Worker wo)
            {
                connectionString = $"CREATE TABLE if not exists {TableName}(" +
                                   $"Id CHAR(256) CONSTRAINT Id PRIMARY KEY," +
                                   $"CreatedDate DATE," +
                                   $"SoftDeletedDate DATE," +
                                   $"TakingOfficeDate DATE," +
                                   $"EmploymentDateTime DATE," +
                                   $"FirstName VARCHAR(30)," +
                                   $"MiddleName VARCHAR(30)," +
                                   $"LastName VARCHAR(30)," +
                                   $"Description VARCHAR(300)," +
                                   $"Age INTEGER(120)," +
                                   $"Gender VARCHAR(8)," +
                                   $"IsDeleted BOOLEAN," +
                                   $")";

            }

            using (var command = new NpgsqlCommand(connectionString, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            connection.Close();
            return TableName;
        }

        public void Add<T>(T person)
        {
            var connection = ConnectDb();
            try
            {
                if (person is Patient patient)
                {
                    string tableName = CreateTable(patient, connection);
                    var cmd = new NpgsqlCommand($"INSERT INTO {tableName} VALUES (" +
                                                $"{patient.Id}," +
                                                $"{patient.CreatedDate}," +
                                                $"{patient.SoftDeletedDate}," +
                                                $"{patient.FirstName}," +
                                                $"{patient.MiddleName}," +
                                                $"{patient.LastName}," +
                                                $"{patient.Age}," +
                                                $"{patient.Gender}," +
                                                $"{patient.IsDeleted}," +
                                                $")", connection);
                    cmd.ExecuteNonQuery();
                }

                if (person is Worker worker)
                {
                    string tableName = CreateTable(worker, connection);
                    var cmd = new NpgsqlCommand($"INSERT INTO {tableName} VALUES (" +
                                                $"{worker.Id}," +
                                                $"{worker.CreatedDate}," +
                                                $"{worker.SoftDeletedDate}," +
                                                $"{worker.TakingOfficeDate}," +
                                                $"{worker.EmploymentDateTime}," +
                                                $"{worker.FirstName}," +
                                                $"{worker.MiddleName}," +
                                                $"{worker.LastName}," +
                                                $"{worker.Age}," +
                                                $"{worker.Gender}," +
                                                $"{worker.IsDeleted}," +
                                                $")", connection);

                    cmd.ExecuteNonQuery();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            string deleteString = $"DELETE FROM {TableName} WHERE BookID={id};";
            var cmd = new NpgsqlCommand(deleteString);
            cmd.ExecuteNonQuery();
        }
    }
}
