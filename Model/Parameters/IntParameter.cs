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
        /// <param name="minValue">Минимально допустимое значение параметра</param>
        /// <param name="maxValue">Максимально допустимое значение параметра.</param>
        IntParameter(string minValue,
                     string maxValue)
            : base(minValue,
                   maxValue)
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
                int correctValue;
                if (int.TryParse(value, out correctValue))
                {
                    _value = value;
                }
            }
        }
    }
}