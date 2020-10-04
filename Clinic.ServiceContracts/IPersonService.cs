using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.ServiceContracts
{
    public interface IPersonService<T>
    {
        T Add(T person);
        void Update(T person);
        T Get(int id);
        void Delete(int id);

        bool IsExist(int id);
    }
}
