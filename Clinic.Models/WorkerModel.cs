﻿using Clinic.Entities;
using System;
using Clinic.Validation.Abstraction;

namespace Clinic.Models
{
    public class WorkerModel : IWorkerModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SoftDeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }
        public DateTime HiringDateTime { get; set; }
        public DateTime StartingWorkDate { get; set; }
        public string Description { get; set; }

    }
}