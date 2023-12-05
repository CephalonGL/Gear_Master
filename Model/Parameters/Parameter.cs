namespace Model
{
    using System;

    /// <summary>
    /// Базовый класс для определения параметров.
    /// </summary>
    public abstract class Parameter
    {
        /// <summary>
        /// Конструткор базового класса.
        /// </summary>
        /// <param name="minValue">Минимальное значение параметра.</param>
        /// <param name="maxValue">Максимальное значение параметра.</param>
        protected Parameter(string minValue, string maxValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }

        /// <summary>
        /// Выполняет проверку
        /// </summary>
        /// <returns></returns>
        public abstract bool IsInRange();

        /// <summary>
        /// Название параметра.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        public virtual string MinValue { get; set; }

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        public virtual string MaxValue { get; set; }
    }
}