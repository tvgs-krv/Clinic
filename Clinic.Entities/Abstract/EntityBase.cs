using System;

namespace Clinic.Entities.Abstract
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SoftDeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
