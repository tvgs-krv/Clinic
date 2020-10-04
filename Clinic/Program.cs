using System;
using Clinic.Domains;
using Clinic.Entities;
using Clinic.Services;

namespace Clinic
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectToPostgreSql"].ConnectionString;
            Patient patient = new Patient
            {
                FirstName = "Венедикт",
                MiddleName = "Альбертович",
                LastName = "Слабоумов",
                CreatedDate = DateTime.Now,
                Age = 32,
                Gender = Gender.Male,
                Id = 2,
                //SoftDeletedDate = DateTime.Now
            };
            patient.MiddleName = "АВДОСИЙ";
            patient.Age = 53;
            PatientsService patientsService = new PatientsService(connectionString);
            patientsService.Add(patient);
            patientsService.Update(patient);
            //patientsService.Delete(3);

            //Console.WriteLine(patientsService.Get(3));

            Console.ReadKey();
        }

    }
}
