namespace Logger
{
    using System;
    using System.IO;
    using Microsoft.Build.Framework;
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
            message = $"{DateTime.Now} | {message}\n";

            var fileWriter = File.AppendText(SavingPath);

            fileWriter.Write(JsonConvert.SerializeObject(message));
            fileWriter.Close();
        }

        /// <summary>
        /// Логгирует строку.
        /// </summary>
        /// <param name="message">Сообщение для логгирования.</param>
        /// <param name="loggingObjects">Объекты для логгирования</param>
        public static void Log(string message, object[] loggingObjects)
        {
            Log(message);

            var fileWriter = File.AppendText(SavingPath);

            if (loggingObjects == null)
            {
                Log("Логгируемый объект(ы) был null.\n");
            }
            else
            {
                fileWriter.Write(JsonConvert.SerializeObject(loggingObjects));
            }

            fileWriter.Close();
        }

        /// <summary>
        /// Сериализовать файл.
        /// </summary>
        /// <param name="message"></param>
        public static void SaveFile(string message)
        {
            File.WriteAllText(SavingPath, JsonConvert.SerializeObject(message));
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        static FileLogger()
        {
            SavingPath = Environment.ExpandEnvironmentVariables(@"%AppData%\ContactList.txt");
        }

        /// <summary>
        /// Путь для сохранения сериализуемых объектов.
        /// </summary>
        private static string SavingPath { get; set; }
    }
}