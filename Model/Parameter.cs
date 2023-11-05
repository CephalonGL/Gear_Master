using System;
using CommunityToolkit.Diagnostics;

namespace Model
{
    /// <summary>
    /// Базовый класс для определения параметров.
    /// </summary>
    public abstract class Parameter
    {
        /// <summary>
        /// Хранит значение параметра.
        /// </summary>
        protected string _value;
        
        /// <summary>
        /// Конструткор базового класса.
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        protected Parameter(string minValue,
                            string maxValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        public string MaxValue { get; private set; }

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        public string MinValue { get; private set; }
        /// <summary>
        /// Значение параметра.
        /// </summary>
        public virtual string Value { get; set; }
    }
}