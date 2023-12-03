namespace Model
{
    using System;

    /// <summary>
    /// Главный класс модели.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Конструктор главного класса модели
        /// </summary>
        /// <param name="builder">Экземпляр построителя</param>
        public Project(ICadBuilder builder)
        {
            Builder = builder;
        }

        /// <summary>
        /// Параметры шестерни.
        /// </summary>
        public GearParameters Parameters { get; set; }

        /// <summary>
        /// Построитель.
        /// </summary>
        private ICadBuilder Builder { get; set; }

        /// <summary>
        /// Команда построения объекта.
        /// </summary>
        public void Build()
        {
            Builder.BuildGear(Parameters);
        }
    }
}