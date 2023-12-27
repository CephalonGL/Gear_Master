namespace Model
{
    using System;

    public class IntParameter : Parameter
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name = "value">Хранимое значение параметра.</param>
        /// <param name="minValue">Минимальное значение параметра.</param>
        /// <param name="maxValue">Максимальное значение параметра.</param>
        public IntParameter(string value, string minValue, string maxValue) : base(value, minValue, maxValue)
        {
        }

        /// <summary>
        /// Проверяет корректность введённых данных.
        /// </summary>
        /// <returns>True, если значение является корректным, иначе - false.</returns>
        public override void AssertCorrect()
        {
            if (!int.TryParse(Value, out var value))
            {
                throw new FormatException();
            }
            
            if (!int.TryParse(MinValue, out var minValue))
            {
                throw new FormatException();
            }
            
            if (!int.TryParse(MaxValue, out var maxValue))
            {
                throw new FormatException();
            }

            if (value < minValue || value > maxValue)
            {
                throw new ArgumentException();
            }
        }
    }
}