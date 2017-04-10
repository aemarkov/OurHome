using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNet.Identity;
using OurHome.Users;

namespace OurHome.Domain
{
    /// <summary>
    /// Потребитель - жилец, тот, кто пользуется коммунальными 
    /// услугами, мониторит и оплачивает их
    /// </summary>
    public class Customer : FullAuditedEntity<long>
    {
        public const int MaxStreetLength = 100;
        public const int MaxBuildingLength = 10;
        public const int MaxFlatLength = 10;

        [Key,ForeignKey("User")]
        public override long Id { get; set; }
        public User User { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

        [Required]
        [MaxLength(MaxStreetLength)]
        public string Street { get; set; }

        [MaxLength(MaxBuildingLength)]
        public string Building { get; set; }

        [MaxLength(MaxFlatLength)]
        public string Flat { get; set; }

        public string Notes { get; set; }

        public ICollection<Registrator> Registrators
        {
            get { return _registrators ?? (_registrators = new List<Registrator>()); }
            set { _registrators = value; }

        }

        private ICollection<Registrator> _registrators { get; set; }
    }
}