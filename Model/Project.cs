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
        public void BuildGear()
        {
            Builder.BuildGear(ExportParameters());
        }

        /// <summary>
        /// Экспортирует параметры шестерни в целевых типах данных.
        /// </summary>
        /// <returns>Параметры шестерни в целевых типах данных.</returns>
        public (
            double outerRadius,
            double holeRadius,
            double thickness,
            double toothHeight,
            int toothCount) ExportParameters()
        {
            return (
                double.Parse(Parameters[ParameterType.OuterRadius].Value),
                double.Parse(Parameters[ParameterType.HoleRadius].Value),
                double.Parse(Parameters[ParameterType.Thickness].Value),
                double.Parse(Parameters[ParameterType.ToothHeight].Value),
                int   .Parse(Parameters[ParameterType.ToothCount].Value));
        }
    }
}