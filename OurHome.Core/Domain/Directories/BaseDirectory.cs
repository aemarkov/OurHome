using Abp.Domain.Entities;

namespace OurHome.Domain.Directories
{
    /// <summary>
    /// Базовый класс справочника
    /// </summary>
    public class BaseDirectory:Entity<string>
    {
        /// <summary>
        /// Строковой идентификатор
        /// </summary>
        public override string Id { get; set; }

        /// <summary>
        /// Человекочитаемое название
        /// </summary>
        public virtual string DisplayText { get; set; }
    }
}