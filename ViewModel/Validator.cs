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
            bool isAbleToBuild,
            string errorMessage,
            ParametersVM gearParametersVM) CheckCorrect(ParametersVM parametersVm)
        {
            var outerRadiusParameter =
                parametersVm.ParameterVMs[ParameterType.OuterRadius].Parameter;

            var holeRadiusParameter =
                parametersVm.ParameterVMs[ParameterType.HoleRadius].Parameter;

            var thicknessParameter =
                parametersVm.ParameterVMs[ParameterType.Thickness].Parameter;

            var toothHeightParameter =
                parametersVm.ParameterVMs[ParameterType.ToothHeight].Parameter;

            var toothCountParameter =
                parametersVm.ParameterVMs[ParameterType.ToothCount].Parameter;

            var isAbleToBuild = true;
            var errorMessage  = string.Empty;

            if (!IsParameterInRange(gearParameters.OuterRadius, 1, 1000))
            {
            }

            try
            {
                AssertCrossValidationCorrect(gearParameters);
            }
            catch (Exception e)
            {
                isAbleToBuild = false;
                errorMessage  = e.Message;
            }

            return (isAbleToBuild, errorMessage, parametersVm);
        }

        /// <summary>
        /// Выполняет проверку зависимых параметров шестерни.
        /// </summary>
        /// <param name="gearParameters">Параметры шестерни.</param>
        /// <exception cref = "Exception">Выбрасывается в случае, если проверка провалена</exception>
        /// <returns>Корректные параметры шестерни.</returns>
        private static GearParameters AssertCrossValidationCorrect(GearParameters gearParameters)
        {
            var errorMessages = new List<string>();

            if (IsHoleRadiusPlusToothHeightMoreOrEqualThanOuterRadius(gearParameters))
            {
                errorMessages
                   .Add("Сумма радиуса отверстия и высоты зуба должна быть больше внешнего радиуса.");
            }

            if (IsToothHeightMoreOrEqualThanOuterRadius(gearParameters))
            {
                errorMessages.Add("Высота зуба должна быть меньше радиуса отверстия.");
            }

            if (errorMessages.Count > 0)
            {
                var totalErrorMessages = string.Empty;

                foreach (var errorMessage in errorMessages)
                {
                    totalErrorMessages += errorMessage;
                    totalErrorMessages += '\n';
                }

                throw new Exception(totalErrorMessages);
            }

            return gearParameters;
        }

        /// <summary>
        /// Определяет, является ли значение высоты зуба больше или равно внешнему радиусу шестерни.
        /// </summary>
        /// <returns>True, если больше или равно, иначе - False.</returns>
        private static bool IsToothHeightMoreOrEqualThanOuterRadius(GearParameters gearParameters)
        {
            var toothHeight   = gearParameters.ToothHeight;
            var outerDiameter = gearParameters.OuterRadius;

            return toothHeight >= outerDiameter;
        }

        /// <summary>
        /// Определяет, является ли сумма радиуса отверстия и высоты зуба больше внешнего диаметра.
        /// </summary>
        /// <returns>True, если является, иначе - False.</returns>
        private static bool IsHoleRadiusPlusToothHeightMoreOrEqualThanOuterRadius(
            GearParameters gearParameters)
        {
            var holeRadius  = gearParameters.HoleRadius;
            var toothHeight = gearParameters.ToothHeight;
            var outerRadius = gearParameters.OuterRadius;

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