namespace Tests
{
    using System;
    using System.Collections.Generic;
    using Model;
    using NUnit.Framework;

    /// <summary>
    /// Тест класса IntParameter.
    /// </summary>
    [TestFixture]
    public class IntParameterTests
    {
        /// <summary>
        /// Генерирует тестовые данные для метода AssertOnAssertCorrect_CorrectValue.
        /// </summary>
        /// <returns>Параметры.</returns>
        private static IEnumerable<Parameter> GetDataForAssertOnAssertCorrect_CorrectValue()
        {
            yield return new IntParameter("10", "1", "100");
            yield return new IntParameter("100", "1", "100");
            yield return new IntParameter("1", "1", "100");
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
            var unparsebleIntValues =
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

            foreach (var unparsebleIntValue in unparsebleIntValues)
            {
                yield return new IntParameter(unparsebleIntValue, "1", "100");
                yield return new IntParameter("10", unparsebleIntValue, "100");
                yield return new IntParameter("10", "1", unparsebleIntValue);
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
            yield return new IntParameter("-10",  "1", "100");
            yield return new IntParameter("0",    "1", "100");
            yield return new IntParameter("101",  "1", "100");
            yield return new IntParameter("1000", "1", "100");
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