namespace ViewModel
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    /// <summary>
    /// Осуществляет перекрёстную валидацию между параметрами.
    /// </summary>
    public static class CrossValidator
    {
        /// <summary>
        /// Хранит переданные параметры в метод AssertOnCorrect.
        /// </summary>
        private static GearParameters Parameters;

        /// <summary>
        /// Выполняет проверку зависимых параметров шестерни.
        /// </summary>
        /// <param name="parameters">Параметры шестерни.</param>
        /// <returns>Корректные параметры шестерни.</returns>
        public static GearParameters AssertOnCorrect(GearParameters parameters)
        {
            Parameters = parameters;
            var errorMessages = new List<string>();

            if (IsHoleRadiusPlusToothHeightMoreOrEqualToOuterRadius())
            {
                errorMessages
                   .Add("Сумма радиуса отверстия и высоты зуба должна быть больше внешнего радиуса.");
            }

            if (IsToothHeightMoreOrEqualToOuterRadius())
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

            return parameters;
        }

        /// <summary>
        /// Определяет, является ли значение высоты зуба больше или равно внешнему радиусу шестерни.
        /// </summary>
        /// <returns>True, если больше или равно, иначе - False.</returns>
        private static bool IsToothHeightMoreOrEqualToOuterRadius()
        {
            var toothHeight   = double.Parse(Parameters.ToothHeight.Value);
            var outerDiameter = double.Parse(Parameters.OuterRadius.Value);

            return toothHeight >= outerDiameter;
        }

        /// <summary>
        /// Определяет, является ли сумма радиуса отверстия и высоты зуба больше внешнего диаметра.
        /// </summary>
        /// <returns>True, если является, иначе - False.</returns>
        private static bool IsHoleRadiusPlusToothHeightMoreOrEqualToOuterRadius()
        {
            var holeRadius  = double.Parse(Parameters.HoleRadius.Value);
            var toothHeight = double.Parse(Parameters.ToothHeight.Value);
            var outerRadius = double.Parse(Parameters.OuterRadius.Value);

            return holeRadius + toothHeight >= outerRadius;
        }
    }
}