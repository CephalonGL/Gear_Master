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
        public static (Dictionary<ParameterType, bool> isParametersCorrect, List<string> errorMessages) IsParametersCorrect(ParametersVM parametersVm)
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

            if (!IsParameterInRange(parametersVm.OuterRadius, minOuterRadius, maxOuterRadius))
            {
                isParametersCorrect[ParameterType.OuterRadius] = false;

                errorMessages.Add($"Внешний радиус шестерни должен находится в диапазоне "
                                  + $"{minOuterRadius} - {maxOuterRadius} мм.");
            }

            if (!IsParameterInRange(parametersVm.HoleRadius, minHoleRadius, maxHoleRadius))
            {
                isParametersCorrect[ParameterType.HoleRadius] = false;

                errorMessages.Add($"Радиус отверстия должен находится в диапазоне "
                                  + $"{minHoleRadius} - {maxHoleRadius} мм.");
            }

            if (!IsParameterInRange(parametersVm.Thickness, minThickness, maxThickness))
            {
                isParametersCorrect[ParameterType.Thickness] = false;

                errorMessages.Add($"Толщина шестерни должна находится в диапазоне "
                                  + $"{minThickness} - {maxThickness} мм.");
            }

            if (!IsParameterInRange(parametersVm.ToothHeight, minToothHeight, maxToothHeight))
            {
                isParametersCorrect[ParameterType.ToothHeight] = false;

                errorMessages.Add($"Высота зуба должна находится в диапазоне "
                                  + $"{minToothHeight} - {maxToothHeight} мм.");
            }

            if (!IsParameterInRange(parametersVm.ToothCount, minToothCount, maxToothCount))
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
            var toothHeight   = parameters.ToothHeight;
            var outerDiameter = parameters.OuterRadius;

            return toothHeight >= outerDiameter;
        }

        /// <summary>
        /// Определяет, является ли сумма радиуса отверстия и высоты зуба больше внешнего диаметра.
        /// </summary>
        /// <returns>True, если является, иначе - False.</returns>
        private static bool IsHoleRadiusPlusToothHeightMoreOrEqualThanOuterRadius(
            ParametersVM parameters)
        {
            var holeRadius  = parameters.HoleRadius;
            var toothHeight = parameters.ToothHeight;
            var outerRadius = parameters.OuterRadius;

            return holeRadius + toothHeight >= outerRadius;
        }

        private static bool IsParameterInRange(int value, int min, int max)
        {
            return min <= value && value <= max;
        }

        private static bool IsParameterInRange(double value, double min, double max)
        {
            return min <= value && value <= max;
        }
    }
}