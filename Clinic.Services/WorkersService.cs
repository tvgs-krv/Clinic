using System;
using System.Configuration;
using Clinic.Domains;
using Clinic.Entities;
using Clinic.Mappers;
using Clinic.Models;
using Clinic.Repositories;
using Clinic.ServiceContracts;

namespace Clinic.Services
{
    public class WorkersService
    {
        private readonly WorkerRepository _workerRepository;

        public WorkersService()
        {
            _workerRepository = new WorkerRepository();
            //string connectionString = ConfigurationManager.ConnectionStrings["connectToPostgreSql"].ConnectionString;
            var cl = ConfigurationManager.OpenExeConfiguration("Clinic.exe");
            string connectionString = cl.ConnectionStrings.ConnectionStrings["connectToPostgreSql"].ConnectionString;
            ////Console.WriteLine(cl.ConnectionStrings.ConnectionStrings["connectToPostgreSql"].ConnectionString);
            //Console.WriteLine(cl.ConnectionStrings.ConnectionStrings["connectToPostgreSql"].ConnectionString);
            ////foreach (var c in cl.ConnectionStrings.ConnectionStrings)
            ////{
            ////    Console.WriteLine(c);
            ////}
            //Console.ReadKey();
            ////var connectionString = ConfigAccess();
            _workerRepository.ConnectionString = connectionString;
            _workerRepository.CreateWorkerTable();
        }

        public Worker Create(WorkerModel workerModel)
        {
            var worker = workerModel.ToDomain();
            _workerRepository.Create(worker);
            return worker;

        }

        public Worker Update(WorkerModel workerModel)
        {
            var worker = workerModel.ToDomain();
            _workerRepository.Update(worker);
            return worker;
        }

        public Worker Get(int id)
        {
            WorkerEntity workerEntity = _workerRepository.Get(id);
            return workerEntity.ToDomain();
        }

        public void Delete(int id)
        {
            _workerRepository.Delete(id);
        }


        private string ConfigAccess()
        {
            Configuration config = null;
            string exeConfigPath = GetType().Assembly.Location;
            try
            {
                config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (config != null)
            {
                var value = GetAppSetting(config, "connectToPostgreSql");
                return value;
            }
            return String.Empty;
        }

        string GetAppSetting(Configuration config, string key)
        {
            KeyValueConfigurationElement element = config.AppSettings.Settings[key];
            if (element != null)
            {
                string value = element.Value;
                if (!string.IsNullOrEmpty(value))
                    return value;
            }
            return string.Empty;
        }

    }
}
