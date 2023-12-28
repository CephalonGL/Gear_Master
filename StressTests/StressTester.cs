namespace StressTests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using AutoCadConnector;
    using Autodesk.AutoCAD.Runtime;
    using Microsoft.VisualBasic.Devices;

    /// <summary>
    /// Класс нагрузочного тестирования.
    /// </summary>
    public class StressTester
    {
        /// <summary>
        /// Количество гигабайт в байте.
        /// </summary>
        private const double GIGABYTE_IN_BYTE = 0.000000000931322574615478515625;

        /// <summary>
        /// Запускает нагрузочное тестирование.
        /// </summary>
        [CommandMethod("StressTest")]
        public void RunStressTest()
        {
            var builder          = new AutoCadBuilder();
            var middleParameters = (500d, 100d, 100d, 100d, 300);

            var stopWatch    = new Stopwatch();
            var streamWriter = new StreamWriter($"log.txt", false);

            var testsCount = 1000;

            for (var i = 0; i < testsCount; i++)
            {
                stopWatch.Start();
                builder.BuildGear(middleParameters);
                stopWatch.Start();
                var computerInfo = new ComputerInfo();

                var usedMemory = (computerInfo.TotalPhysicalMemory
                                  - computerInfo.AvailablePhysicalMemory)
                                 * GIGABYTE_IN_BYTE;

                streamWriter
                   .WriteLine($"{i + 1};{stopWatch.ElapsedMilliseconds};{usedMemory}");

                stopWatch.Reset();
                streamWriter.Flush();
            }

            stopWatch.Stop();
            streamWriter.Close();
            streamWriter.Dispose();
            Console.Write($"End {new ComputerInfo().TotalPhysicalMemory}");
        }
    }
}