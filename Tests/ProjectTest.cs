namespace Tests
{
    using System.Collections.Generic;
    using AutoCadConnector;
    using Model;
    using NUnit.Framework;

    /// <summary>
    /// Выполняет проверку класса Project.
    /// </summary>
    [TestFixture]
    public class ProjectTest
    {
        /// <summary>
        /// Хранит экземпляр проекта.
        /// </summary>
        private Project Project { get; set; }

        /// <summary>
        /// Запускается перед выполнением каждого теста.
        /// </summary>
        [SetUp]
        [Description("Выполняется перед запуском каждого теста.")]
        public void SetUp()
        {
            Project = new Project(new AutoCadBuilder());
        }

        /// <summary>
        /// Выполняет проверку сеттера Parameters.
        /// </summary>
        [Test]
        [Description("Выполняет проверку сеттера Parameters.")]
        public void AssertOnParametersSetter_CorrectValue()
        {
            Assert.DoesNotThrow(() => Project.Parameters =
                                    new Dictionary<ParameterType, Parameter>());
        }

        /// <summary>
        /// Выполняет проверку геттера Parameters.
        /// </summary>
        [Test]
        [Description("Выполняет проверку геттера Parameters.")]
        public void AssertOnParametersGetter_CorrectValue()
        {
            var expected = new Dictionary<ParameterType, Parameter>();
            Project.Parameters = expected;
            Assert.That(expected, Is.EqualTo(Project.Parameters));
        }
    }
}