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
        /// Минимальное значение параметра.
        /// </summary>
        protected string _maxValue;

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        protected string _minValue;

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
        /// Название параметра.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        public virtual string MaxValue
        {
            get => _maxValue;
            set => _maxValue = value;
        }

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        public virtual string MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public virtual string Value
        {
            get => _value;
            set => _value = value;
        }
    }
}