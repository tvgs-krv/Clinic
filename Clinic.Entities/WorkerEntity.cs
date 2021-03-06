﻿using System;
using Clinic.Entities.Abstract;

namespace Clinic.Entities
{
    public class WorkerEntity:EntityBase, IPersonEntity, IWorkerEntity
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }
        public DateTime EmploymentDateTime { get; set; }
        public DateTime TakingOfficeDate { get; set; }
        public string Description { get; set; }
    }
}
