namespace ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
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
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            
            var errorMessages = new List<string>();

            var isParametersCorrect = new Dictionary<ParameterType, bool>()
                                      {
                                          { ParameterType.OuterRadius, true },
                                          { ParameterType.HoleRadius, true },
                                          { ParameterType.Thickness, true },
                                          { ParameterType.ToothHeight, true },
                                          { ParameterType.ToothCount, true },
                                      };

            var isUnparseble = false;

            var outerRadiusParameter =
                parametersVm.Parameters[ParameterType.OuterRadius];

            if (!double.TryParse(outerRadiusParameter.Value, out var valueOuterRadius))
            {
                errorMessages.Add($"Значение {outerRadiusParameter.Value} не соответствует "
                                  + $"целевому типу данных.");

                isParametersCorrect[ParameterType.OuterRadius] = false;
                isUnparseble                                   = true;
            }

            var minOuterRadius = double.Parse(outerRadiusParameter.MinValue);
            var maxOuterRadius = double.Parse(outerRadiusParameter.MaxValue);

            var holeRadiusParameter =
                parametersVm.Parameters[ParameterType.HoleRadius];

            if (!double.TryParse(holeRadiusParameter.Value, out var valueHoleRadius))
            {
                errorMessages.Add($"Значение {holeRadiusParameter.Value} не соответствует "
                                  + $"целевому типу данных.");

                isParametersCorrect[ParameterType.HoleRadius] = false;
                isUnparseble                                  = true;
            }

            var minHoleRadius = double.Parse(holeRadiusParameter.MinValue);
            var maxHoleRadius = double.Parse(holeRadiusParameter.MaxValue);

            var thicknessParameter =
                parametersVm.Parameters[ParameterType.Thickness];

            if (!double.TryParse(thicknessParameter.Value, out var valueThickness))
            {
                errorMessages.Add($"Значение {thicknessParameter.Value} не соответствует "
                                  + $"целевому типу данных.");

                isParametersCorrect[ParameterType.Thickness] = false;
                isUnparseble                                 = true;
            }

            var minThickness = double.Parse(thicknessParameter.MinValue);
            var maxThickness = double.Parse(thicknessParameter.MaxValue);

            var toothHeightParameter =
                parametersVm.Parameters[ParameterType.ToothHeight];

            if (!double.TryParse(toothHeightParameter.Value, out var valueToothHeight))
            {
                errorMessages.Add($"Значение {toothHeightParameter.Value} не соответствует "
                                  + $"целевому типу данных.");

                isParametersCorrect[ParameterType.ToothHeight] = false;
                isUnparseble                                   = true;
            }

            var minToothHeight = double.Parse(toothHeightParameter.MinValue);
            var maxToothHeight = double.Parse(toothHeightParameter.MaxValue);

            var toothCountParameter =
                parametersVm.Parameters[ParameterType.ToothCount];

            if (!int.TryParse(toothCountParameter.Value, out var valueToothCount))
            {
                errorMessages.Add($"Значение {toothCountParameter.Value} не соответствует "
                                  + $"целевому типу данных.");

                isParametersCorrect[ParameterType.ToothCount] = false;
                isUnparseble                                  = true;
            }

            var minToothCount = int.Parse(toothCountParameter.MinValue);
            var maxToothCount = int.Parse(toothCountParameter.MaxValue);

            if (isUnparseble)
            {
                return (isParametersCorrect, errorMessages);
            }

            if (!IsParameterInRange(valueOuterRadius, minOuterRadius, maxOuterRadius))
            {
                isParametersCorrect[ParameterType.OuterRadius] = false;

                errorMessages.Add($"Внешний радиус шестерни должен находится в диапазоне "
                                  + $"{minOuterRadius} - {maxOuterRadius} мм.");
            }

            if (!IsParameterInRange(valueHoleRadius, minHoleRadius, maxHoleRadius))
            {
                isParametersCorrect[ParameterType.HoleRadius] = false;

                errorMessages.Add($"Радиус отверстия должен находится в диапазоне "
                                  + $"{minHoleRadius} - {maxHoleRadius} мм.");
            }

            if (!IsParameterInRange(valueThickness, minThickness, maxThickness))
            {
                isParametersCorrect[ParameterType.Thickness] = false;

                errorMessages.Add($"Толщина шестерни должна находится в диапазоне "
                                  + $"{minThickness} - {maxThickness} мм.");
            }

            if (!IsParameterInRange(valueToothHeight, minToothHeight, maxToothHeight))
            {
                isParametersCorrect[ParameterType.ToothHeight] = false;

                errorMessages.Add($"Высота зуба должна находится в диапазоне "
                                  + $"{minToothHeight} - {maxToothHeight} мм.");
            }

            if (!IsParameterInRange(valueToothCount, minToothCount, maxToothCount))
            {
                isParametersCorrect[ParameterType.ToothCount] = false;

                errorMessages.Add($"Количество зубьев должно находится в диапазоне "
                                  + $"{minToothCount} - {maxToothCount} шт.");
            }

            if (valueToothHeight >= valueOuterRadius)
            {
                isParametersCorrect[ParameterType.ToothHeight] = false;
                isParametersCorrect[ParameterType.OuterRadius] = false;

                errorMessages.Add($"Высота зуба ({valueToothHeight}) должна быть меньше "
                                  + $"внешнего радиуса ({valueOuterRadius}).");
            }

            if (valueHoleRadius + valueToothHeight >= valueOuterRadius)
            {
                isParametersCorrect[ParameterType.HoleRadius]  = false;
                isParametersCorrect[ParameterType.ToothHeight] = false;
                isParametersCorrect[ParameterType.OuterRadius] = false;

                errorMessages.Add($"Сумма радиуса отверстия ({valueHoleRadius}) и "
                                  + $"высоты зуба ({valueToothHeight}) должна быть меньше "
                                  + $"внешнего радиуса ({valueOuterRadius}).");
            }

            return (isParametersCorrect, errorMessages);
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