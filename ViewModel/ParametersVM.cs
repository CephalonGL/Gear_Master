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
            var outerRadius = new DoubleParameter("100", "1",   "1000");
            var holeRadius  = new DoubleParameter("15",  "1",   "999");
            var thickness   = new DoubleParameter("10",  "1",   "1000");
            var toothHeight = new DoubleParameter("30",  "0.1", "999");
            var toothCount  = new IntParameter("14", "3", "1000");

            var outerRadiusDescription =
                $"Внешний радиус шестерни ({outerRadius.MinValue} - {outerRadius.MaxValue})";

            var holeRadiusDescription =
                $"Радиус отверстия ({holeRadius.MinValue} - {holeRadius.MaxValue})";

            var thicknessDescription =
                $"Толщина шестерни ({thickness.MinValue} - {thickness.MaxValue})";

            var toothHeightDescription =
                $"Количество зубьев ({toothHeight.MinValue} - {toothHeight.MaxValue})";

            var toothCountDescription =
                $"Количество зубьев ({toothCount.MinValue} - {toothCount.MaxValue})";

            Parameters = new Dictionary<ParameterType, ParameterVM>
                         {
                             {
                                 ParameterType.OuterRadius,
                                 new ParameterVM(outerRadiusDescription, outerRadius)
                             },
                             {
                                 ParameterType.HoleRadius,
                                 new ParameterVM(holeRadiusDescription, holeRadius)
                             },
                             {
                                 ParameterType.Thickness,
                                 new ParameterVM(thicknessDescription, thickness)
                             },
                             {
                                 ParameterType.ToothHeight,
                                 new ParameterVM(toothHeightDescription, toothHeight)
                             },
                             {
                                 ParameterType.ToothCount,
                                 new ParameterVM(toothCountDescription, toothCount)
                             },
                         };
        }

        /// <summary>
        /// Параметры шестерни.
        /// </summary>
        public Dictionary<ParameterType, ParameterVM> Parameters { get; private set; }

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