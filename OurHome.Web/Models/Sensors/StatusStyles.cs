namespace OurHome.Web.Models.Sensors
{
    /// <summary>
    /// css-стили, используемые для оформления сообщений
    /// (хорошо-предупреждение-плохо)
    /// </summary>
    public class StatusStyles
    {
        /// <summary>
        /// Стиль цвета
        /// </summary>
        public string ColorStyle { get; private set; }

        /// <summary>
        /// Стиль иконки
        /// </summary>
        public string IconStyle { get; set; }


        public static StatusStyles FromLevel(StatusLevel level)
        {
            var style = new StatusStyles();

            if (level == StatusLevel.GOOD)
            {
                style.IconStyle = "glyphicon-ok-circle";
                style.ColorStyle = "good";
            }
            else if (level == StatusLevel.WARNING)
            {
                style.IconStyle = "glyphicon-warning-sign";
                style.ColorStyle = "warning";
            }
            else
            {
                style.IconStyle = "glyphicon-remove-circle";
                style.ColorStyle = "error";
            }

            return style;
        }

    }
}