namespace Model.Parameters
{
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
        DoubleParameter(string maxValue,
                        string minValue)
            : base(maxValue,
                   minValue)
        {
        }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public override string Value
        {
            get => _value;
            set
            {
                double correctValue;
                if (double.TryParse(value, out correctValue))
                {
                    _value = value;
                }
            }
        }
    }
}