using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Entities.Abstract
{
    public interface IPersonEntity
    {
        string FirstName { get; set; }
        string? MiddleName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        Gender Gender { get; set; }

    }
}
