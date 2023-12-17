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
            var outerRadius = new Parameter("100", "1",   "1000");
            var holeRadius  = new Parameter("15",  "1",   "999");
            var thickness   = new Parameter("10",  "1",   "1000");
            var toothHeight = new Parameter("30", "0.1", "999");
            var toothCount  = new Parameter("14",  "3",   "1000");

            Parameters = new Dictionary<ParameterType, Parameter>()
                         {
                             { ParameterType.OuterRadius, outerRadius },
                             { ParameterType.HoleRadius, holeRadius },
                             { ParameterType.Thickness, thickness },
                             { ParameterType.ToothHeight, toothHeight },
                             { ParameterType.ToothCount, toothCount },
                         };
        }
        
        /// <summary>
        /// Параметры шестерни.
        /// </summary>
        public Dictionary<ParameterType, Parameter> Parameters { get; private set; }

        /// <summary>
        /// Экспортирует параметры в целевых типах данных.
        /// </summary>
        /// <returns>Параметры в целевых типах данных.</returns>
        public (
            double outerRadius,
            double holeRadius,
            double thickness,
            double toothHeight,
            int toothCount)
            ExportParameters()
        {
            return (double.Parse(Parameters[ParameterType.OuterRadius].Value),
                    double.Parse(Parameters[ParameterType.HoleRadius].Value),
                    double.Parse(Parameters[ParameterType.Thickness].Value),
                    double.Parse(Parameters[ParameterType.ToothHeight].Value),
                    int.Parse(Parameters[ParameterType.ToothCount].Value));
        }

    }
}