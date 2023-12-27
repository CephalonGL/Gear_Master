using System;
using NUnit.Framework;

namespace Tests
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using Model;
    using ViewModel;

    /// <summary>
    /// Тесты для класса ParametersVM.
    /// </summary>
    [TestFixture]
    public class ParametersVMTest
    {
        /// <summary>
        /// Устанавливает начальные условия для тестов.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            ParametersVM               = new ParametersVM();
        }

        /// <summary>
        /// Хранит тестируемый экземпляр ParametersVM.
        /// </summary>
        public ParametersVM ParametersVM { get; set; }

        /// <summary>
        /// Проверяет экспорт параметров.
        /// </summary>
        [Test]
        [Description("Проверяет экспорт параметров.")]
        public void AssertExportParameters_CorrectValue()
        {
            var expected = (100d, 15d, 10d, 30d, 14);
            var actual   = ParametersVM.ExportParameters();
            Assert.That(expected, Is.EqualTo(actual));
        }

        /// <summary>
        /// Проверяет геттер параметров.
        /// </summary>
        [Test]
        [Description("Проверяет геттер параметров.")]
        public void AssertGetParameters_CorrectValue()
        {
            var actual = ParametersVM.Parameters;
            Assert.Pass();
        }

        /// <summary>
        /// Проверяет геттер корректности параметров.
        /// </summary>
        [Test]
        [Description("Проверяет геттер корректности параметров.")]
        public void AssertGetParametersCorrectness_CorrectValue()
        {
            var actual = ParametersVM.ParametersCorrectness;
            Assert.Pass();
        }

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
        public void AssertOnValidateParameters_CorrectValue(ParametersVM parametersVm)
        {
            var validationResult = parametersVm.ValidateParameters();

            if (validationResult.isCorrect
                && validationResult.errorMessage.Length == 0)
            {
                Assert.Pass();
            }

            Assert.Fail("Валидация провалена, когда данные верны.");
        }


        private static IEnumerable<ParametersVM> GetDataForValidateParameters_IncorrectValue()
        {
            //Нулевые параметры.
            yield return GenerateParameters("0",   "1", "1", "0.1", "3");
            yield return GenerateParameters("1.2", "0", "1", "0.1", "3");
            yield return GenerateParameters("1.2", "1", "0", "0.1", "3");
            yield return GenerateParameters("1.2", "1", "1", "0",   "3");
            yield return GenerateParameters("1.2", "1", "1", "0.1", "0");

            //Пустые параметры.
            yield return GenerateParameters("",    "1", "1", "0.1", "3");
            yield return GenerateParameters("1.2", "",  "1", "0.1", "3");
            yield return GenerateParameters("1.2", "1", "",  "0.1", "3");
            yield return GenerateParameters("1.2", "1", "1", "",    "3");
            yield return GenerateParameters("1.2", "1", "1", "0.1", "");

            //Параметры больше максимума.
            yield return GenerateParameters("1001", "400",  "1000", "200",  "1000");
            yield return GenerateParameters("1000", "1001", "1000", "200",  "1000");
            yield return GenerateParameters("1000", "400",  "1001", "200",  "1000");
            yield return GenerateParameters("1000", "400",  "1000", "1001", "1000");
            yield return GenerateParameters("1000", "400",  "1000", "200",  "1001");

            //Параметры меньше минимума.
            yield return GenerateParameters("-1000", "400",  "1000",  "200",  "1000");
            yield return GenerateParameters("1000",  "-400", "1000",  "200",  "1000");
            yield return GenerateParameters("1000",  "400",  "-1000", "200",  "1000");
            yield return GenerateParameters("1000",  "400",  "1000",  "-200", "1000");
            yield return GenerateParameters("1000",  "400",  "1000",  "200",  "-1000");

            //Параметры нецелевого типа данных.
            yield return GenerateParameters("asdaf", "400",   "1000",  "200",   "1000");
            yield return GenerateParameters("1000",  "asdaf", "1000",  "200",   "1000");
            yield return GenerateParameters("1000",  "400",   "asdaf", "200",   "1000");
            yield return GenerateParameters("1000",  "400",   "1000",  "asdaf", "1000");
            yield return GenerateParameters("1000",  "400",   "1000",  "200",   "asdaf");

            //Параметры не подходящие по кросс-валидации.
            yield return GenerateParameters("100",  "50",  "10",   "50",  "14");
            yield return GenerateParameters("100", "400", "10", "200", "14");
        }


        /// <summary>
        /// Позитивный тест валидации параметров.
        /// </summary>
        /// <param name="parametersVm">Представление вида для параметров.</param>
        [TestCaseSource(nameof(GetDataForValidateParameters_IncorrectValue))]
        [Description("Позитивный тест валидации параметров.")]
        public void AssertOnIsParametersCorrect_IncorrectValue(ParametersVM parametersVm)
        {
            var validationResult = parametersVm.ValidateParameters();

            if (validationResult.isCorrect
                && validationResult.errorMessage.Length == 0)
            {
                Assert.Fail("Валидация пройдена, когда данные неверны.");
            }
            else
            {
                Assert.Pass();
            }
        }
    }
}