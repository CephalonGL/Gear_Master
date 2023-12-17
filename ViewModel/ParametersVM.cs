namespace ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using CommunityToolkit.Mvvm.Input;
    using Model;

    /// <summary>
    /// Представление для параметров шестерни в VM.
    /// </summary>
    public class ParametersVM
    {
        /// <summary>
        /// Конструктор, инициализирующий .
        /// </summary>
        public ParametersVM()
        {
            var cultureInfo = CultureInfo.InvariantCulture;
            ParameterVMs = new Dictionary<ParameterType, ParameterVM>
                           {
                               {
                                   ParameterType.OuterRadius,
                                   new ParameterVM(1.0d.ToString(cultureInfo), 
                                                   1.0d.ToString(cultureInfo),
                                                   1000.0d.ToString(cultureInfo))
                               },
                               {
                                   ParameterType.HoleRadius,
                                   new ParameterVM(1.0d.ToString(cultureInfo), 
                                                   1.0d.ToString(cultureInfo),
                                                   999.0d.ToString(cultureInfo))
                               },
                               {
                                   ParameterType.Thickness,
                                   new ParameterVM(1.0d.ToString(cultureInfo), 
                                                   1.0d.ToString(cultureInfo),
                                                   1000.0d.ToString(cultureInfo))
                               },
                               {
                                   ParameterType.ToothHeight,
                                   new ParameterVM(0.1d.ToString(cultureInfo), 
                                                   0.1d.ToString(cultureInfo),
                                                   999.0d.ToString(cultureInfo))
                               },
                               {
                                   ParameterType.ToothCount,
                                   new ParameterVM(3.ToString(), 
                                                   3.ToString(),
                                                   1000.ToString())
                               }
                           };
        }

        /// <summary>
        /// Хранит парамеры шестерни.
        /// </summary>
        public Dictionary<ParameterType, ParameterVM> ParameterVMs { get; private set; }

        /// <summary>
        /// Предоставляет внешний радиус в целевом типе данных.
        /// </summary>
        public double OuterRadius =>
            double.Parse(ParameterVMs[ParameterType.OuterRadius].Parameter.Value);

        /// <summary>
        /// Предоставляет радиус отверстия в целевом типе данных.
        /// </summary>
        public double HoleRadius =>
            double.Parse(ParameterVMs[ParameterType.OuterRadius].Parameter.Value);

        /// <summary>
        /// Предоставляет толщину в целевом типе данных.
        /// </summary>
        public double Thickness =>
            double.Parse(ParameterVMs[ParameterType.OuterRadius].Parameter.Value);

        /// <summary>
        /// Предоставляет Высоту зуба в целевом типе данных.
        /// </summary>
        public double ToothHeight =>
            double.Parse(ParameterVMs[ParameterType.OuterRadius].Parameter.Value);

        /// <summary>
        /// Предоставляет количество зубьев в целевом типе данных.
        /// </summary>
        public int ToothCount => int.Parse(ParameterVMs[ParameterType.OuterRadius].Parameter.Value);
    }
}