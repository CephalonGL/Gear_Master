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
                $"Высота зуба ({toothHeight.MinValue} - {toothHeight.MaxValue})";

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

            ParametersCorrectness = new Dictionary<ParameterType, bool>
                                    {
                                        { ParameterType.OuterRadius, true },
                                        { ParameterType.HoleRadius, true },
                                        { ParameterType.Thickness, true },
                                        { ParameterType.ToothHeight, true },
                                        { ParameterType.ToothCount, true }
                                    };
        }

        /// <summary>
        /// Выполняет проверку пользовательского ввода.
        /// </summary>
        /// <returns>
        /// True, если валидация прошла успешно, иначе - false; сообщение об ошибке.
        /// </returns>
        public (bool isCorrect, string errorMessage) ValidateParameters()
        {
            var errorMessages = new List<string>();

            foreach (var parameterKeyValuePair in Parameters)
            {
                try
                {
                    ParametersCorrectness[parameterKeyValuePair.Key] = true;
                    parameterKeyValuePair.Value.AssertCorrect();
                }
                catch (FormatException exception)
                {
                    ParametersCorrectness[parameterKeyValuePair.Key] = false;

                    errorMessages.Add($"Значение {parameterKeyValuePair.Value.Value} "
                                      + $"не соответствует целевому типу данных.");
                }
                catch (ArgumentException exception)
                {
                    ParametersCorrectness[parameterKeyValuePair.Key] = false;

                    errorMessages.Add($"{parameterKeyValuePair.Value.Description} "
                                      + $"находится вне допустимого диапазона.");
                }
            }

            var isValidationCorrect = true;
            var errorMessage        = string.Empty;

            if (errorMessages.Count > 0)
            {
                for (var i = 0; i < errorMessages.Count; i++)
                {
                    errorMessage += $"{errorMessages[i]}\n";
                }

                isValidationCorrect = false;
            }

            return (isValidationCorrect, errorMessage);
        }

        /// <summary>
        /// Отображает корректность введённых параметров
        /// </summary>
        public Dictionary<ParameterType, bool> ParametersCorrectness { get; private set; }

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