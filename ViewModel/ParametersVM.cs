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
        /// Конструктор.
        /// </summary>
        public ParametersVM()
        {
            var cultureInfo = CultureInfo.InvariantCulture;

            ParameterVMs = new Dictionary<ParameterType, ParameterVM>
                           {
                               {
                                   ParameterType.OuterRadius,
                                   new ParameterVM(1d.ToString(cultureInfo),
                                                   1d.ToString(cultureInfo),
                                                   1000d.ToString(cultureInfo))
                               },
                               {
                                   ParameterType.HoleRadius,
                                   new ParameterVM(1d.ToString(cultureInfo),
                                                   1d.ToString(cultureInfo),
                                                   999d.ToString(cultureInfo))
                               },
                               {
                                   ParameterType.Thickness,
                                   new ParameterVM(1d.ToString(cultureInfo),
                                                   1d.ToString(cultureInfo),
                                                   1000d.ToString(cultureInfo))
                               },
                               {
                                   ParameterType.ToothHeight,
                                   new ParameterVM(0.1d.ToString(cultureInfo),
                                                   0.1d.ToString(cultureInfo),
                                                   999d.ToString(cultureInfo))
                               },
                               {
                                   ParameterType.ToothCount, new ParameterVM(3.ToString(),
                                       3.ToString(),
                                       1000.ToString())
                               }
                           };
        }

        /// <summary>
        /// Хранит парамеры шестерни.
        /// </summary>
        public Dictionary<ParameterType, ParameterVM> ParameterVMs { get; private set; }

        public (
            double outerRadius,
            double holeRadius,
            double thickness,
            double toothHeight,
            int toothCount)
            ExportParameters()
        {
            return (double.Parse(OuterRadius), 
                    double.Parse(HoleRadius), 
                    double.Parse(Thickness), 
                    double.Parse(ToothHeight), 
                    int.Parse(ToothCount));
        }

        /// <summary>
        /// Предоставляет внешний радиус в целевом типе данных.
        /// </summary>
        public string OuterRadius
        {
            get => ParameterVMs[ParameterType.OuterRadius].Parameter.Value;
            set => ParameterVMs[ParameterType.OuterRadius].Parameter.Value = value;
        }

        /// <summary>
        /// Предоставляет радиус отверстия в целевом типе данных.
        /// </summary>
        public string HoleRadius
        {
            get => ParameterVMs[ParameterType.HoleRadius].Parameter.Value;
            set => ParameterVMs[ParameterType.HoleRadius].Parameter.Value = value;
        }

        /// <summary>
        /// Предоставляет толщину в целевом типе данных.
        /// </summary>
        public string Thickness
        {
            get => ParameterVMs[ParameterType.Thickness].Parameter.Value;
            set => ParameterVMs[ParameterType.Thickness].Parameter.Value = value;
        }
        
        /// <summary>
        /// Предоставляет Высоту зуба в целевом типе данных.
        /// </summary>
        public string ToothHeight
        {
            get => ParameterVMs[ParameterType.ToothHeight].Parameter.Value;
            set => ParameterVMs[ParameterType.ToothHeight].Parameter.Value = value;
        }
        
        /// <summary>
        /// Предоставляет количество зубьев в целевом типе данных.
        /// </summary>
        public string ToothCount
        {
            get => ParameterVMs[ParameterType.ToothCount].Parameter.Value;
            set => ParameterVMs[ParameterType.ToothCount].Parameter.Value = value;
        }
    }
}