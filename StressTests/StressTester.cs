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
        /// Запускает нагрузочное тестирование.
        /// </summary>
        [CommandMethod("RunStressTest")]
        public void RunStressTest()
        {
            var builder          = new AutoCadBuilder();
            var middleParameters = (700d, 300d, 500d, 200d, 500);

            var stopWatch    = new Stopwatch();
            var streamWriter = new StreamWriter($"log.txt", false);

            // var currentProcess = Process.GetCurrentProcess();

            var testsCount = 100;

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
                   .WriteLine($"{i+1};{stopWatch.ElapsedMilliseconds};{usedMemory}");

                stopWatch.Reset();
                streamWriter.Flush();
            }

            stopWatch.Stop();
            streamWriter.Close();
            streamWriter.Dispose();
            Console.Write($"End {new ComputerInfo().TotalPhysicalMemory}");
        }

        private const double GIGABYTE_IN_BYTE = 0.000000000931322574615478515625;
    }
}