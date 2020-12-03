using System;
using System.Data;
using Clinic.Domains;
using Clinic.Entities;
using Clinic.Mappers;
using Clinic.Models;
using Clinic.Repositories;
using Clinic.ServiceContracts;

namespace Clinic.Services
{
    public class PatientsService
    {
        private readonly PatientRepository _patientRepository;

        public PatientsService()
        {
            _patientRepository = new PatientRepository();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectToPostgreSql"].ConnectionString;
            _patientRepository.ConnectionString = connectionString;
            _patientRepository.CreatePatientTable();
        }

        public Patient Create(PatientModel patientModel)
        {
            var patient = patientModel.ToDomain();
            _patientRepository.Create(patient);
            return patient;
        }

        public Patient Update(PatientModel patientModel)
        {
            var patient = patientModel.ToDomain();
            _patientRepository.Update(patient);
            return patient;
        }

        public Patient Get(int id)
        {
            PatientEntity patient = _patientRepository.Get(id);
            return patient.ToDomain();
        }

        public void Delete(int id)
        {
            _patientRepository.Delete(id);
        }


    }
}
