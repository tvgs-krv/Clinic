using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domains;
using Clinic.Repositories.Abstract;

namespace Clinic.Repositories
{
    public class PatientRepository : BaseRepository
    {
       

       public PatientRepository()
       {
           TableName = "Patients";
       }
    }
}
