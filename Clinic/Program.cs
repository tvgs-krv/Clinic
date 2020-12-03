using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Clinic.Controllers;
using Clinic.Entities;
using Clinic.Models;
using Clinic.Services;

namespace Clinic
{
    class Program
    {
        static void Main(string[] args)
        {
            //PatientModel patient = new PatientModel
            //{
            //    FirstName = "Венедикт",
            //    MiddleName = "Альбертович",
            //    LastName = "Слабоумов",
            //    CreatedDate = DateTime.Now,
            //    Age = 32,
            //    Gender = Gender.Male,
            //    Id = 2,
            //    //SoftDeletedDate = DateTime.Now
            //};
            //patient.MiddleName = "Вельзевул";
            //patient.Age = 23;
            //PatientsService patientsService = new PatientsService();
            //PatientController patientController = new PatientController(patientsService);


            //patientController.Delete(2);

            WorkerModel wm = new WorkerModel();
            wm.Id = 10;
            wm.Age = 150;
            wm.FirstName = "Альфред";
            wm.MiddleName = "Широнян";
            wm.LastName = "SSSSSS";
            wm.Position = Position.Worker;
            wm.Gender = Gender.Female;
            wm.CreatedDate = DateTime.Now;
            var context = new ValidationContext(wm);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(wm, context, results, true);

            if (isValid)
            {
                WorkersService ws = new WorkersService();
                WorkerController wc = new WorkerController(ws);
                wc.Update(wm);
            }
            else
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }

            }

            //Console.WriteLine($"{getPatient.Id}\t{getPatient.FirstName}\t{getPatient.MiddleName}\t{getPatient.Gender}\t{getPatient.CreatedDate}");

            //wc.Delete(10);
            Console.ReadKey();
        }

    }
}
