using System;

namespace OurHome.Web.Models.Sensors
{
    /// <summary>
    /// Краткая информация о состоянии счетчика
    /// </summary>
    public class BriefSensorViewModel
    {
        public int Id { get; set; }
        public SensorType Type { get; set; }
        public DateTime LastUpdate { get; set; }
        public SensorStatus Status { get; set; }

        /// <summary>
        /// Расход ресурса за месяц
        /// </summary>
        public float ResourcesPerMonth { get; set; }

        /// <summary>
        /// Стоимость ресурса за месяц
        /// </summary>
        public float MoneyPerMonth { get; set; }

        /// <summary>
        /// Задолженность
        /// </summary>
        public float Debt { get; set; }
    }
}