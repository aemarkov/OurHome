namespace OurHome.Web.Models.Sensors
{
    /// <summary>
    /// Строка состояния счетчика
    /// </summary>
    public class SensorMessage
    {
        public StatusLevel Status { get; set; }
        public string Message { get; set; }
    }
}