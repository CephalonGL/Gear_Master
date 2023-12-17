namespace ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Net.NetworkInformation;
    using Model;

    /// <summary>
    /// Осуществляет перекрёстную валидацию между параметрами.
    /// </summary>
    public static class Validator
    {
        public static (
            Dictionary<ParameterType, bool> ParametersCorrectness,
            List<string> errorMessages)
            IsParametersCorrect(ParametersVM parametersVm)
        {
            var minOuterRadius = 1d;
            var maxOuterRadius = 1000d;

            var outerRadiusParameter =
                parametersVm.ParameterVMs[ParameterType.OuterRadius].Parameter;

            var minHoleRadius = 1d;
            var maxHoleRadius = 999d;

            var holeRadiusParameter =
                parametersVm.ParameterVMs[ParameterType.HoleRadius].Parameter;

            var minThickness = 1d;
            var maxThickness = 1000d;

            var thicknessParameter =
                parametersVm.ParameterVMs[ParameterType.Thickness].Parameter;

            var minToothHeight = 0.1d;
            var maxToothHeight = 1000d;

            var toothHeightParameter =
                parametersVm.ParameterVMs[ParameterType.ToothHeight].Parameter;

            var minToothCount = 3;
            var maxToothCount = 1000;

            var toothCountParameter =
                parametersVm.ParameterVMs[ParameterType.ToothCount].Parameter;

            var isParametersCorrect = new Dictionary<ParameterType, bool>()
                                      {
                                          { ParameterType.OuterRadius, true },
                                          { ParameterType.HoleRadius, true },
                                          { ParameterType.Thickness, true },
                                          { ParameterType.ToothHeight, true },
                                          { ParameterType.ToothCount, true },
                                      };

            var errorMessages = new List<string>();

            if (!IsParameterInRange(double.Parse(parametersVm.OuterRadius), minOuterRadius, maxOuterRadius))
            {
                isParametersCorrect[ParameterType.OuterRadius] = false;

                errorMessages.Add($"Внешний радиус шестерни должен находится в диапазоне "
                                  + $"{minOuterRadius} - {maxOuterRadius} мм.");
            }

            if (!IsParameterInRange(double.Parse(parametersVm.HoleRadius), minHoleRadius, maxHoleRadius))
            {
                isParametersCorrect[ParameterType.HoleRadius] = false;

                errorMessages.Add($"Радиус отверстия должен находится в диапазоне "
                                  + $"{minHoleRadius} - {maxHoleRadius} мм.");
            }

            if (!IsParameterInRange(double.Parse(parametersVm.Thickness), minThickness, maxThickness))
            {
                isParametersCorrect[ParameterType.Thickness] = false;

                errorMessages.Add($"Толщина шестерни должна находится в диапазоне "
                                  + $"{minThickness} - {maxThickness} мм.");
            }

            if (!IsParameterInRange(double.Parse(parametersVm.ToothHeight), minToothHeight, maxToothHeight))
            {
                isParametersCorrect[ParameterType.ToothHeight] = false;

                errorMessages.Add($"Высота зуба должна находится в диапазоне "
                                  + $"{minToothHeight} - {maxToothHeight} мм.");
            }

            if (!IsParameterInRange(int.Parse(parametersVm.ToothCount), minToothCount, maxToothCount))
            {
                isParametersCorrect[ParameterType.ToothCount] = false;

                errorMessages.Add($"Количество зубьев должно находится в диапазоне "
                                  + $"{minToothCount} - {maxToothCount} шт.");
            }

            if (IsToothHeightMoreOrEqualThanOuterRadius(parametersVm))
            {
                isParametersCorrect[ParameterType.ToothHeight] = false;
                isParametersCorrect[ParameterType.OuterRadius] = false;

                errorMessages.Add($"Высота зуба ({parametersVm.ToothHeight}) должна быть меньше "
                                  + $"внешнего радиуса ({parametersVm.OuterRadius}).");
            }

            if (IsHoleRadiusPlusToothHeightMoreOrEqualThanOuterRadius(parametersVm))
            {
                isParametersCorrect[ParameterType.HoleRadius]  = false;
                isParametersCorrect[ParameterType.ToothHeight] = false;
                isParametersCorrect[ParameterType.OuterRadius] = false;

                errorMessages.Add($"Сумма радиуса отверстия ({parametersVm.HoleRadius}) и "
                                  + $"высоты зуба ({parametersVm.ToothHeight}) должна быть меньше "
                                  + $"внешнего радиуса({parametersVm.OuterRadius}).");
            }

            return (isParametersCorrect, errorMessages);
        }

        /// <summary>
        /// Определяет, является ли значение высоты зуба больше или равно внешнему радиусу шестерни.
        /// </summary>
        /// <returns>True, если больше или равно, иначе - False.</returns>
        private static bool IsToothHeightMoreOrEqualThanOuterRadius(ParametersVM parameters)
        {
            var toothHeight   = double.Parse(parameters.ToothHeight);
            var outerDiameter = double.Parse(parameters.OuterRadius);

            return toothHeight >= outerDiameter;
        }

        /// <summary>
        /// Определяет, является ли сумма радиуса отверстия и высоты зуба больше внешнего диаметра.
        /// </summary>
        /// <returns>True, если является, иначе - False.</returns>
        private static bool IsHoleRadiusPlusToothHeightMoreOrEqualThanOuterRadius(
            ParametersVM parameters)
        {
            var holeRadius  = double.Parse(parameters.HoleRadius);
            var toothHeight = double.Parse(parameters.ToothHeight);
            var outerRadius = double.Parse(parameters.OuterRadius);;

            return holeRadius + toothHeight >= outerRadius;
        }

        /// <summary>
        /// Определяет, находится ли параметр в заданном диапазоне значений. Нестрогое сравнение.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="min">Нижняя границы диапазона.</param>
        /// <param name="max">Верхняя граница диапазона.</param>
        /// <returns>True, если находится, иначе - false.</returns>
        private static bool IsParameterInRange(int value, int min, int max)
        {
            return min <= value && value <= max;
        }

        /// <summary>
        /// Определяет, находится ли параметр в заданном диапазоне значений. Нестрогое сравнение.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="min">Нижняя границы диапазона.</param>
        /// <param name="max">Верхняя граница диапазона.</param>
        /// <returns>True, если находится, иначе - false.</returns>
        private static bool IsParameterInRange(double value, double min, double max)
        {
            return min <= value && value <= max;
        }
    }
}