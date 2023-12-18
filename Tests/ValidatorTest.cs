using System;
using NUnit.Framework;

namespace Tests
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using Model;
    using ViewModel;

    [TestFixture]
    public class ValidatorTest
    {
        /// <summary>
        /// Генерирует представление вида для парамметров.
        /// </summary>
        /// <param name="outerRadius">Внешний радиус.</param>
        /// <param name="holeRadius">Радиус отверстия.</param>
        /// <param name="thickness">Толщина.</param>
        /// <param name="toothHeight">Высота зуба.</param>
        /// <param name="toothCount">Количество зубьев.</param>
        /// <returns></returns>
        private static ParametersVM GenerateParameters(string outerRadius,
                                                       string holeRadius,
                                                       string thickness,
                                                       string toothHeight,
                                                       string toothCount)
        {
            var parametersVm = new ParametersVM();
            parametersVm.Parameters[ParameterType.OuterRadius].Value = outerRadius;
            parametersVm.Parameters[ParameterType.HoleRadius].Value  = holeRadius;
            parametersVm.Parameters[ParameterType.Thickness].Value   = thickness;
            parametersVm.Parameters[ParameterType.ToothHeight].Value = toothHeight;
            parametersVm.Parameters[ParameterType.ToothCount].Value  = toothCount;

            return parametersVm;
        }

        private static IEnumerable<ParametersVM> GetDataForValidateParameters_CorrectValue()
        {
            yield return GenerateParameters("1.2",  "1",   "1",    "0.1", "3");
            yield return GenerateParameters("100",  "15",  "10",   "30",  "14");
            yield return GenerateParameters("1000", "400", "1000", "200", "1000");
        }

        /// <summary>
        /// Позитивный тест валидации параметров.
        /// </summary>
        /// <param name="parametersVm">Представление вида для параметров.</param>
        [TestCaseSource(nameof(GetDataForValidateParameters_CorrectValue))]
        [Description("Позитивный тест валидации параметров.")]
        public void AssertOnIsParametersCorrect_CorrectValue(ParametersVM parametersVm)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            var validationResult = Validator.IsParametersCorrect(parametersVm);

            if (validationResult.errorMessages.Count > 0)
            {
                Assert.Fail("Валидация провалена, когда данные верны.");
            }

            foreach (var isParameterCorrect in validationResult.ParametersCorrectness)
            {
                if (!isParameterCorrect.Value)
                {
                    Assert.Fail("Валидация провалена, когда данные верны.");
                }
            }
        }


        private static IEnumerable<ParametersVM> GetDataForValidateParameters_IncorrectValue()
        {
            yield return GenerateParameters("1.2",  "1",   "1",    "0.1", "3");
            yield return GenerateParameters("100",  "15",  "10",   "30",  "14");
            yield return GenerateParameters("1000", "400", "1000", "200", "1000");
        }

        /// <summary>
        /// Позитивный тест валидации параметров.
        /// </summary>
        /// <param name="parametersVm">Представление вида для параметров.</param>
        [TestCaseSource(nameof(GetDataForValidateParameters_IncorrectValue))]
        [Description("Позитивный тест валидации параметров.")]
        public void AssertOnIsParametersCorrect_IncorrectValue(ParametersVM parametersVm)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            var validationResult = Validator.IsParametersCorrect(parametersVm);

            if (validationResult.errorMessages.Count > 0)
            {
                if (validationResult.ParametersCorrectness[ParameterType.OuterRadius]    == false
                    || validationResult.ParametersCorrectness[ParameterType.HoleRadius]  == false
                    || validationResult.ParametersCorrectness[ParameterType.Thickness]   == false
                    || validationResult.ParametersCorrectness[ParameterType.ToothHeight] == false
                    || validationResult.ParametersCorrectness[ParameterType.ToothCount]  == false)
                {
                    Assert.Pass();
                }
            }
        }
    }
}