using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace OurHome.Domain
{
    /// <summary>
    /// Город
    /// </summary>
    public class City:Entity
    {
        public const int MaxCityNameLength = 32;

        [Required]
        [MaxLength(MaxCityNameLength)]
        public string CityName { get; set; }
    }
}