namespace Model
{
    using System;
    using System.Collections.Generic;

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
        public Dictionary<ParameterType, Parameter> Parameters { get; set; }

        /// <summary>
        /// Построитель.
        /// </summary>
        private ICadBuilder Builder { get; set; }

        /// <summary>
        /// Команда построения объекта.
        /// </summary>
        /// <param name = "exportedParameters">Параметры для построения.</param>
        public void BuildGear(
            (double outerRadius,
             double holeRadius, 
             double thickness, 
             double toothHeight, 
             int toothCount) exportedParameters)
        {
            Builder.BuildGear(exportedParameters);
        }
    }
}