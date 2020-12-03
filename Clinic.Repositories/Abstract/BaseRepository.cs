using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domains;
using Clinic.Entities;
using Clinic.Entities.Abstract;
using Npgsql;
using static System.String;

namespace Clinic.Repositories.Abstract
{
    public class BaseRepository : IRepository
    {
        public string TableName { get; set; }

        public string ConnectionString { get; set; }

        public NpgsqlConnection ConnectDb()
        {
            //request = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=123456789";
            return new NpgsqlConnection(ConnectionString);
        }

        private string CreateTable<T>(T tableColumns, NpgsqlConnection connection)
        {
            if (IsNullOrEmpty(TableName))
                throw new ArgumentNullException(nameof(TableName));
            if (tableColumns == null)
                throw new ArgumentNullException(nameof(tableColumns));
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            string connectionString = Empty;

            if (tableColumns is Patient)
                connectionString = $"CREATE TABLE if not exists {TableName} (" +
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

            if (tableColumns is Worker)
            {
                connectionString = $"CREATE TABLE if not exists {TableName} (" +
                                   $"Id INTEGER CONSTRAINT Id PRIMARY KEY," +
                                   $"CreatedDate DATE," +
                                   $"SoftDeletedDate DATE," +
                                   $"StartingWorkDate DATE," +
                                   $"HiringDateTime DATE," +
                                   $"FirstName VARCHAR(30)," +
                                   $"MiddleName VARCHAR(30)," +
                                   $"LastName VARCHAR(30)," +
                                   $"Description VARCHAR(300)," +
                                   $"Age INTEGER," +
                                   $"Gender VARCHAR(8)," +
                                   $"Position VARCHAR(10)," +
                                   $"IsDeleted BOOLEAN" +
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

        public string CreateEntity(string request)
        {
            var connection = ConnectDb();

            if (IsNullOrEmpty(TableName))
                throw new ArgumentNullException(nameof(TableName));
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));
            if (IsNullOrEmpty(request))
                throw new ArgumentNullException(nameof(request));

            using (var command = new NpgsqlCommand(request, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            connection.Close();
            return TableName;
        }


        private void CreateEntityInDb<T>(T person)
        {
            var connection = ConnectDb();
            try
            {
                string insert = Empty;
                if (person is PatientEntity patient)
                {
                    string softDeleteDate;
                    var softDel = patient.SoftDeletedDate;
                    if (softDel != null)
                    {
                        softDeleteDate = "'" + softDel.Value.ToString("yyyy-MM-dd") + "'";
                    }
                    else
                    {
                        softDeleteDate = "NULL";
                    }

                    insert = $"INSERT INTO {TableName} VALUES (" +
                             $"{patient.Id}," +
                             $"'{patient.CreatedDate}'," +
                            $"{softDeleteDate}," +
                            $"'{patient.FirstName}'," +
                            $"'{patient.MiddleName}'," +
                            $"'{patient.LastName}'," +
                            $"'{patient.Age}'," +
                            $"'{patient.Gender}'," +
                            $"{patient.IsDeleted}" +
                            $") ON CONFLICT (id) DO NOTHING";
                }

                if (person is WorkerEntity workerEntity)
                {
                    string softDeleteDate;
                    var softDel = workerEntity.SoftDeletedDate;
                    if (softDel != null)
                    {
                        softDeleteDate = "'" + softDel.Value.ToString("yyyy-MM-dd") + "'";
                    }
                    else
                    {
                        softDeleteDate = "NULL";
                    }

                    insert = $"INSERT INTO {TableName} VALUES (" +
                             $"{workerEntity.Id}," +
                             $"'{workerEntity.CreatedDate}'," +
                             $"{softDeleteDate}," +
                             $"'{workerEntity.StartingWorkDate}'," +
                             $"'{workerEntity.HiringDateTime}'," +
                             $"'{workerEntity.FirstName}'," +
                             $"'{workerEntity.MiddleName}'," +
                             $"'{workerEntity.LastName}'," +
                             $"'{workerEntity.Description}'," +
                             $"'{workerEntity.Age}'," +
                             $"'{workerEntity.Gender}'," +
                             $"'{workerEntity.Position}'," +
                             $"{workerEntity.IsDeleted}" +
                             $") ON CONFLICT (id) DO NOTHING";
                }



                using (var command = new NpgsqlCommand(insert, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public DataTable GetDataFromDb(int id)
        {
            var connection = ConnectDb();
            string sql = $"SELECT * FROM {TableName} where id='{id}'";
            connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
            {
                NpgsqlDataReader reader = cmd.ExecuteReader();
                DataTable getElement = new DataTable();
                getElement.Load(reader);
                connection.Close();
                return getElement;
            }
        }

        public void UpdateDataInDb(DataTable personEntity)
        {
            var id = personEntity.Rows[0].Field<int>("id");
            var connection = ConnectDb();
            connection.Open();
            string sql = $"UPDATE {TableName} SET " +
                         //$"softdeleteddate = :softdeleteddate, " +
                         $"firstname = :firstname, " +
                         $"middlename = :middlename, " +
                         $"lastname = :lastname, " +
                         $"age = :age, " +
                         $"gender = :gender, " +
                         $"isdeleted = :isdeleted " +
                         $"WHERE id = {id}";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
            {
                //cmd.Parameters.Create(new NpgsqlParameter("softdeleteddate", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("firstname", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("middlename", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("lastname", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("age", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("gender", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("isdeleted", NpgsqlTypes.NpgsqlDbType.Boolean));
                //cmd.Parameters[0].Value = "NULL";
                //cmd.Parameters[0].Value = personEntity.Rows[0].Field<DateTime?>("softdeleteddate");
                cmd.Parameters[0].Value = personEntity.Rows[0].Field<string>("firstname");
                cmd.Parameters[1].Value = personEntity.Rows[0].Field<string>("middlename");
                cmd.Parameters[2].Value = personEntity.Rows[0].Field<string>("lastname");
                cmd.Parameters[3].Value = personEntity.Rows[0].Field<int>("age");
                cmd.Parameters[4].Value = personEntity.Rows[0].Field<string>("gender");
                cmd.Parameters[5].Value = personEntity.Rows[0].Field<bool>("isdeleted");
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void Delete(int id)
        {
            #region Delete/Drop
            //string deleteString = $"DELETE FROM {TableName} WHERE id='{id}'";
            //var connection = ConnectDb();
            //connection.Open();
            //using (NpgsqlCommand cmd = new NpgsqlCommand(deleteString, connection))
            //{
            //    cmd.ExecuteNonQuery();
            //}
            //connection.Close();
            #endregion

            #region SoftDelete
            var connection = ConnectDb();
            connection.Open();
            string sql = $"UPDATE {TableName} SET " +
                         $"softdeleteddate = :softdeleteddate, " +
                         $"isdeleted = :isdeleted " +
                         $"WHERE id = {id}";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
            {
                cmd.Parameters.Add(new NpgsqlParameter("softdeleteddate", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("isdeleted", NpgsqlTypes.NpgsqlDbType.Boolean));
                cmd.Parameters[0].Value = DateTime.Now;
                cmd.Parameters[1].Value = true;
                cmd.ExecuteNonQuery();
            }
            connection.Close();
            #endregion

        }

        public bool IsExist(int id)
        {
            var connection = ConnectDb();
            bool dbExists;
            string cmdText = $"select 1 from {TableName} where id='{id}'";
            connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand(cmdText, connection))
            {
                dbExists = cmd.ExecuteScalar() != null;
            }
            connection.Close();

            return dbExists;
        }
    }
}
