﻿using System;
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
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectToPostgreSql"].ConnectionString;
            PatientModel patient = new PatientModel
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
            patient.MiddleName = "Вельзевул";
            patient.Age = 23;
            PatientsService patientsService = new PatientsService(connectionString);
            PatientController patientController = new PatientController(patientsService);

            //Console.WriteLine($"{getPatient.Id}\t{getPatient.FirstName}\t{getPatient.MiddleName}\t{getPatient.Gender}\t{getPatient.CreatedDate}");

            patientController.Delete(2);
            Console.ReadKey();
        }

    }
}
