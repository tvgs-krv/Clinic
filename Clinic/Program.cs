using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using Npgsql;

namespace Clinic
{
    class Program
    {


        static void Main(string[] args)
        {
            string connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=123456789";
            //string connectionString = "Server=127.0.0.1;Port=5432;Database=test;User Id=postgres;Password=123456789";

            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            try
            {
                if (connection.State == ConnectionState.Closed)
                {


                    //connection.Open();
                    //var cmd = new NpgsqlCommand("INSERT INTO empoyee VALUES (1, 'Galaxy S9', 'Samsung', 'male', 'male','2000-10-09')", connection); //Вставить значение
                    //var m_createdb_cmd = new NpgsqlCommand(@"CREATE TABLE table1(ID CHAR(256) CONSTRAINT id PRIMARY KEY, Title CHAR)", connection); //Создать таблцу
                    //m_createdb_cmd.ExecuteNonQuery();

                    //var m_createdb_cmd = new NpgsqlCommand(@"
                    //                                                CREATE DATABASE testDb
                    //                                                WITH OWNER = postgres
                    //                                                ENCODING = 'UTF8'
                    //                                                CONNECTION LIMIT = -1;
                    //                                                ", connection);
                    //connection.Open();
                    //m_createdb_cmd.ExecuteNonQuery();
                    //connection.Close();

                }
                Console.WriteLine(connection.State.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

    }
}
