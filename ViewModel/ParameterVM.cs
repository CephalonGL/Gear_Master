namespace ViewModel
{
    using Model;

    /// <summary>
    /// Представление параметра.
    /// </summary>
    public class ParameterVM
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name = "description">Описание параметра.</param>
        /// <param name="parameter">Хранимый параметр.</param>
        public ParameterVM(string description, Parameter parameter)
        {
            this.Parameter   = parameter;
            this.Description = description;
        }

        /// <summary>
        /// Параметр.
        /// </summary>
        private Parameter Parameter { get; set; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public string Value
        {
            get => Parameter.Value;
            set => Parameter.Value = value;
        }

        /// <summary>
        /// Описание параметра.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Указывает, является ли значение параметра корректным.
        /// </summary>
        public bool CheckCorrect()
        {
            return this.Parameter.CheckCorrect();
        }
    }
}