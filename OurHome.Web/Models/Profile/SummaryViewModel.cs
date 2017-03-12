using System.Collections.Generic;
using OurHome.Web.Models.Sensors;

namespace OurHome.Web.Models.Profile
{
    /// <summary>
    /// Модель для сводки
    /// </summary>
    public class SummaryViewModel
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public IEnumerable<BriefSensorViewModel> Sensors { get; set; }

        public float TotalMoney { get; set; }
        public float TotalDept { get; set; }
    }
}