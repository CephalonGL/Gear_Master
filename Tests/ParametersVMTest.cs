namespace Tests
{
    using System;
    using Model;
    using NUnit.Framework;
    using ViewModel;

    /// <summary>
    /// Выполняет проверку класса ParametersVM.
    /// </summary>
    [TestFixture]
    public class ParametersVMTest
    {
        /// <summary>
        /// Хранит экземпляр ParametersVM.
        /// </summary>
        ParametersVM ParametersVM { get; set; }

        /// <summary>
        /// Устанавливает начальные значения при запуске каждого теста.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            ParametersVM = new ParametersVM();
        }

        /// <summary>
        /// Выполняет проверку экспорта параметров при корректных значениях.
        /// </summary>
        [Test]
        public void AssertOnExportParameters_CorrectValues()
        {
            ParametersVM.Parameters[ParameterType.OuterRadius].Value = "100";
            ParametersVM.Parameters[ParameterType.HoleRadius].Value  = "15";
            ParametersVM.Parameters[ParameterType.Thickness].Value   = "10";
            ParametersVM.Parameters[ParameterType.ToothHeight].Value = "30";
            ParametersVM.Parameters[ParameterType.ToothCount].Value  = "14";

            var result = ParametersVM.ExportParameters();

            if (result.outerRadius    == 100d
                && result.holeRadius  == 15d
                && result.thickness   == 10d
                && result.toothHeight == 30d
                && result.toothCount  == 14)
            {
                Assert.Pass();
            }
        }

        /// <summary>
        /// Выполняет проверку экспорта параметров при некорректных значениях.
        /// </summary>
        [Test]
        public void AssertOnExportParameters_IncorrectValues()
        {
            ParametersVM.Parameters[ParameterType.OuterRadius].Value = "-asds0";
            ParametersVM.Parameters[ParameterType.HoleRadius].Value  = "15";
            ParametersVM.Parameters[ParameterType.Thickness].Value   = "10";
            ParametersVM.Parameters[ParameterType.ToothHeight].Value = "30";
            ParametersVM.Parameters[ParameterType.ToothCount].Value  = "14";

            Assert.Throws<FormatException>(() => ParametersVM.ExportParameters());
        }
    }
}