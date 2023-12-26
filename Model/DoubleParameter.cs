namespace Model
{
    using System;
    using System.Globalization;

    public class DoubleParameter : Parameter
    {
        /// <summary>
        /// Конструктор базового класса.
        /// </summary>
        /// <param name = "value">Хранимое значение параметра.</param>
        /// <param name="minValue">Минимальное значение параметра.</param>
        /// <param name="maxValue">Максимальное значение параметра.</param>
        public DoubleParameter(string value, string minValue, string maxValue) :
            base(value, minValue, maxValue)
        {
        }

        /// <summary>
        /// Проверяет корректность введённых данных.
        /// </summary>
        /// <returns>True, если значение является корректным, иначе - false.</returns>
        public override void AssertCorrect()
        {
            if (!double.TryParse(Value, out var value))
            {
                throw new FormatException();
            }

            if (!double.TryParse(Value, out var minValue))
            {
                throw new FormatException();
            }

            if (!double.TryParse(Value, out var maxValue))
            {
                throw new FormatException();
            }

            if (value < minValue &&  maxValue < value)
            {
                throw new ArgumentException();
            }
        }
    }
}