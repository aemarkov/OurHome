using Abp.Domain.Entities;

namespace OurHome.Domain.Directories
{
    /// <summary>
    /// Базовый класс справочника
    /// </summary>
    public class BaseDirectory:Entity
    {
        /// <summary>
        /// Строковой идентификатор
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Человекочитаемое название
        /// </summary>
        public virtual string DisplayText { get; set; }
    }
}