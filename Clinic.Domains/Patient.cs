﻿
using System;
using Clinic.Entities;

namespace Clinic.Domains
{
    public class Patient 
        // Вот здесь не понятно, мне нужно создать аналогичные интерфейсы со свойствами как в слое DATA?
        // или же вынести эти интерфейсы в отдельный слой и уже их вставлять как независимые от слоя
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SoftDeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

    }
}
