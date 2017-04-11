using System.ComponentModel.DataAnnotations;

namespace OurHome.Domain.Directories
{
    /// <summary>
    /// Тип коммунального ресурса
    /// </summary>
    public class ResourceType : BaseDirectory
    {
        [Required]
        [MaxLength(10)]
        public override string Value { get; set; }

        [Required]
        [MaxLength(32)]
        public override string DisplayText { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Unit { get; set; }

        public static string ELECTRICITY = "ELECTRICIT";
        public static string GAS = "GAS";
        public static string HOT_WATER = "HOT_WATER";
        public static string COLD_WATER = "COLD_WATER";
    }
}