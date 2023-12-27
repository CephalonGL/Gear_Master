namespace Tests
{
    using System;
    using Model;
    using NUnit.Framework;
    using ViewModel;

    /// <summary>
    /// Тесты класса ParameterVM.
    /// </summary>
    [TestFixture]
    public class ParameterVMTest
    {
        /// <summary>
        /// Позитивный тест для сеттера параметра.
        /// </summary>
        [Test]
        [Description("Позитивный тест для сеттера параметра.")]
        public void Parameter_CorrectValue()
        {
            var parameterVM = new ParameterVM("123", new IntParameter("10", "1", "100"));
            Assert.Pass();
        }

        /// <summary>
        /// Позитивный тест для сеттера описания.
        /// </summary>
        [Test]
        [Description("Позитивный тест для сеттера описания.")]
        public void SetDescription_CorrectValue()
        {
            var expected    = "expectedDescription";
            var parameterVM = new ParameterVM(expected, new IntParameter("10", "1", "100"));
            var actual      = parameterVM.Description;
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Позитивный тест для сеттера описания.
        /// </summary>
        [Test]
        [Description("Позитивный тест для сеттера описания.")]
        public void GetDescription_CorrectValue()
        {
            var parameterVM = new ParameterVM("description", new IntParameter("10", "1", "100"));
            Assert.Pass();
        }

        /// <summary>
        /// Позитивный тест для сеттера значения параметра.
        /// </summary>
        [Test]
        [Description("Позитивный тест для сеттера значения параметра.")]
        public void SetValue_CorrectValue()
        {
            var parameterVM = new ParameterVM("description", new IntParameter("10", "1", "100"));
            parameterVM.Value = "11";
            Assert.Pass();
        }


        /// <summary>
        /// Позитивный тест для геттера значения параметра.
        /// </summary>
        [Test]
        [Description("Позитивный тест для геттера значения параметра.")]
        public void GetValue_CorrectValue()
        {
            var parameterVM = new ParameterVM("description", new IntParameter("10", "1", "100"));
            var expected    = "11";
            parameterVM.Value = expected;
            var actual = parameterVM.Value;
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Позитивный тест вызова метода AssertCorrect.
        /// </summary>
        [Test]
        [Description("Позитивный тест вызова метода AssertCorrect.")]
        public void AssertCorrect_CorrectValue()
        {
            var parameterVM = new ParameterVM("description", new IntParameter("10", "1", "100"));
            parameterVM.AssertCorrect();
            Assert.Pass();
        }

        /// <summary>
        /// Негативный тест вызова метода AssertCorrect.
        /// </summary>
        [Test]
        [Description("Негативный тест вызова метода AssertCorrect.")]
        public void AssertCorrect_IncorrectValue()
        {
            var parameterVM = new ParameterVM("description", new IntParameter("-10", "1", "100"));

            try
            {
                parameterVM.AssertCorrect();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
        }
    }
}