using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using OurHome.Domain.Directories;

namespace OurHome.Domain
{
    /// <summary>
    /// Регистратор - записывает показания одного счетчика
    /// </summary>
    public class Registrator : FullAuditedEntity
    {
        [Required]
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int ResourceId { get; set; }
        public ResourceType Resource { get; set; }

        public ICollection<ResourceConsumption> ConsumptionHistory
        {
            get { return _consumptionHistory ?? (_consumptionHistory = new List<ResourceConsumption>()); }
            set { _consumptionHistory = value; }
        }
        private ICollection<ResourceConsumption> _consumptionHistory;
    }
}