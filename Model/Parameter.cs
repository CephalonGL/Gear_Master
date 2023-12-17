namespace Model
{
    using System;

    /// <summary>
    /// Базовый класс для определения параметров.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Конструктор базового класса.
        /// </summary>
        /// <param name = "value">Хранимое значение параметра.</param>
        /// <param name="minValue">Минимальное значение параметра.</param>
        /// <param name="maxValue">Максимальное значение параметра.</param>
        public Parameter(string value, string minValue, string maxValue)
        {
            Value = value;
            MaxValue = maxValue;
            MinValue = minValue;
        }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        public string MinValue { get; set; }

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        public string MaxValue { get; set; }
    }
}