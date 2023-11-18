namespace Model.Parameters
{
    /// <summary>
    /// Целочисленный параметр.
    /// </summary>
    public class IntParameter : Parameter
    {
        /// <summary>
        /// Конструктор целочисленного параметра.
        /// </summary>
        /// <param name="minValue">Минимально допустимое значение параметра.</param>
        /// <param name="maxValue">Максимально допустимое значение параметра.</param>
        public IntParameter(string minValue, string maxValue)
            : base(minValue, maxValue)
        {
        }

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        public string MaxValue
        {
            get => _maxValue;
            set => _maxValue = value;
        }

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        public string MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        /// <inheritdoc/>
        public override string Value
        {
            get => _value;
            set
            {
                int correctValue;

                if (int.TryParse(value, out correctValue))
                {
                    _value = value;
                }
            }
        }
    }
}