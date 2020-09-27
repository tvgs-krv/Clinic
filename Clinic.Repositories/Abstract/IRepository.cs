using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Clinic.Repositories.Abstract
{
    public interface IRepository
    {
        string TableName { get; set; }
        NpgsqlConnection ConnectDb();
        string CreateTable<T>(T tableColumns, NpgsqlConnection connection);
        void Add<T>(T person);
        void Update(int id);
        void Delete(int id);

    }
}
