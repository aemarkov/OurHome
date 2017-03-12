using System.Collections;
using System.Collections.Generic;

namespace OurHome.Web.Models.Sensors
{
    /// <summary>
    /// Состояние счетчика
    /// </summary>
    public class SensorStatus
    {
        /// <summary>
        /// Уровень заряда батаери, 0-100
        /// </summary>
        public int BatteryLevel { get; set; }

        /// <summary>
        /// Состояние счетчика
        /// </summary>
        public StatusLevel Status { get; set; }

        /// <summary>
        /// Сообщения
        /// </summary>
        public IEnumerable<SensorMessage> Messages { get; set; }

    }
}