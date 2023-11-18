namespace Model.Parameters
{
    using System;

    /// <summary>
    /// Параметр числа с плавающей запятой двойной точности.
    /// </summary>
    public class DoubleParameter : Parameter
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="minValue">Минимально допустимое значение параметра.</param>
        /// <param name="maxValue">Максимально допустимое значение параметра.</param>
        public DoubleParameter(string maxValue, string minValue)
            : base(maxValue, minValue)
        {
        }

        public override string MaxValue
        {
            get => _maxValue;
            set
            {
                
                _maxValue = value;
            }
        }

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        public override string MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public override string Value
        {
            get => _value;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(null, "Parameter must be instantiated.");
                }

                if (!double.TryParse(value, out var doubleValue))
                {
                    throw new ArgumentException("Value must be double.");
                }

                if (doubleValue <= double.Parse(MinValue))
                {
                    throw new
                        ArgumentOutOfRangeException(null, $"Value must be more or equal to {MinValue}.");
                }

                if (doubleValue >= double.Parse(MaxValue))
                {
                    throw new
                        ArgumentOutOfRangeException(null, $"Value must be less or equal to {MaxValue}.");
                }

                _value = value;
            }
        }
    }
}