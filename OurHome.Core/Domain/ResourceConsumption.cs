using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace OurHome.Domain
{
    public class ResourceConsumption : CreationAuditedEntity
    {
        public override DateTime CreationTime { get; set; }
        public float Consumption { get; set; }

        [Required]
        public int RegistratorId { get; set; }
        public Registrator Registrator { get; set; }
    }
}