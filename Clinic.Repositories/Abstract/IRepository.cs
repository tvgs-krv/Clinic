using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Entities;
using Clinic.Entities.Abstract;
using Npgsql;

namespace Clinic.Repositories.Abstract
{
    public interface IRepository
    {
        string TableName { get; set; }
        NpgsqlConnection ConnectDb();
        string CreateTable<T>(T tableColumns, NpgsqlConnection connection);
        void Add<T>(T person);

        DataTable Get(int id);
        void Update(DataTable person);
        void Delete(int id);
        bool IsExist(int id);

    }
}
