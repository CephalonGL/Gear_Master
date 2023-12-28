namespace Logger
{
    using System;
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    /// Логгирует файл
    /// </summary>
    public static class FileLogger
    {
        /// <summary>
        /// Логгирует строку.
        /// </summary>
        /// <param name="message">Сообщение для логгирования.</param>
        public static void Log(string message)
        {
            message = $"{DateTime.Now} | {message}";

            var fileWriter = File.AppendText(SavingPath);

            fileWriter.WriteLine(JsonConvert.SerializeObject(message, Formatting.Indented));
            fileWriter.Close();
        }

        /// <summary>
        /// Логгирует строку.
        /// </summary>
        /// <param name="message">Сообщение для логгирования.</param>
        /// <param name="loggingObject">Объекты для логгирования.</param>
        public static void Log(string message, object loggingObject)
        {
            Log(message);

            var fileWriter = File.AppendText(SavingPath);
            fileWriter.WriteLine(JsonConvert.SerializeObject(loggingObject, Formatting.Indented));
            fileWriter.Close();
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        static FileLogger()
        {
            SavingPath = Environment.ExpandEnvironmentVariables(@"%AppData%\GearMasterLog.txt");
        }

        /// <summary>
        /// Путь для сохранения сериализуемых объектов.
        /// </summary>
        private static string SavingPath { get; set; }
    }
}