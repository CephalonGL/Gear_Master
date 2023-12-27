namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Model;
    using NUnit.Framework;
    using ViewModel;

    /// <summary>
    /// Тест класса DoubleParameter.
    /// </summary>
    [TestFixture]
    public class DoubleParameterTest
    {
        /// <summary>
        /// Устанавливает начальные настройки тестов.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        /// <summary>
        /// Генерирует тестовые данные для метода AssertOnAssertCorrect_CorrectValue.
        /// </summary>
        /// <returns>Параметры.</returns>
        private static IEnumerable<Parameter> GetDataForAssertOnAssertCorrect_CorrectValue()
        {
            yield return new DoubleParameter("10,0", "1,0", "100,0");
            yield return new DoubleParameter("10.0", "1.0", "100.0");
            yield return new DoubleParameter("3.5",  "3.0", "4.0");
            yield return new DoubleParameter("1.0",  "0.0", "10.0");
        }

        /// <summary>
        /// Позитивный тест валидации параметров.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        [TestCaseSource(nameof(GetDataForAssertOnAssertCorrect_CorrectValue))]
        [Description("Позитивный тест валидации параметров.")]
        public void AssertOnAssertCorrect_CorrectValue(Parameter parameter)
        {
            Assert.DoesNotThrow(() => parameter.AssertCorrect());
        }

        /// <summary>
        /// Генерирует тестовые данные для метода AssertOnAssertCorrect_CorrectValue.
        /// </summary>
        /// <returns>Параметры.</returns>
        private static IEnumerable<Parameter>
            GetDataForAssertOnAssertCorrect_UnparsebleIncorrectValue()
        {
            var unparsebleDoubleValues =
                new List<string>()
                {
                    "..0",
                    "0..0",
                    "1-2.0",
                    "+",
                    "-",
                    "*",
                    "(",
                    ")",
                    "^",
                    "&",
                    "|",
                    "="
                };

            foreach (var unparsebleDoubleValue in unparsebleDoubleValues)
            {
                yield return new DoubleParameter(unparsebleDoubleValue, "1.0", "100.0");
                yield return new DoubleParameter("10.0", unparsebleDoubleValue, "100.0");
                yield return new DoubleParameter("10.0", "1.0", unparsebleDoubleValue);
            }
        }

        /// <summary>
        /// Негативный тест валидации параметров.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        [TestCaseSource(nameof(GetDataForAssertOnAssertCorrect_UnparsebleIncorrectValue))]
        [Description("Негативный тест валидации параметров.")]
        public void AssertOnAssertCorrect_UnparsebleIncorrectValue(Parameter parameter)
        {
            Assert.Throws<FormatException>(() => parameter.AssertCorrect());
        }


        /// <summary>
        /// Генерирует тестовые данные для метода 
        /// GetDataForAssertOnAssertCorrect_IncorrectArgumentValue.
        /// </summary>
        /// <returns>Параметры.</returns>
        private static IEnumerable<Parameter>
            GetDataForAssertOnAssertCorrect_IncorrectArgumentValue()
        {
            yield return new DoubleParameter("-10.0",  "1.0", "100.0");
            yield return new DoubleParameter("0.9",    "1.0", "100.0");
            yield return new DoubleParameter("100.1",  "1.0", "100.0");
            yield return new DoubleParameter("1000.0", "1.0", "100.0");
        }

        /// <summary>
        /// Негативный тест валидации параметров.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        [TestCaseSource(nameof(GetDataForAssertOnAssertCorrect_IncorrectArgumentValue))]
        [Description("Негативный тест валидации параметров.")]
        public void AssertOnAssertCorrect_IncorrectArgumentValue(Parameter parameter)
        {
            Assert.Throws<ArgumentException>(() => parameter.AssertCorrect());
        }
    }
}