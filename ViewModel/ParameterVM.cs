namespace ViewModel
{
    using System.Windows;
    using CommunityToolkit.Mvvm;
    using CommunityToolkit.Mvvm.ComponentModel;
    using Model;

    /// <summary>
    /// Представление параметра.
    /// </summary>
    public class ParameterVM
    {
        /// <summary>
        /// Параметры.
        /// </summary>
        [ObservableProperty]
        private Parameter _parameter;
        
        /// <summary>
        /// Отображает состояние корректности данных.
        /// </summary>
        public bool IsCorrect { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public ParameterVM(string value, string min, string max)
        {
            Parameter = new Parameter(value, min, max);
        }

        /// <summary>
        /// Параметры.
        /// </summary>
        public Parameter Parameter
        {
            get => _parameter;
            private set => _parameter = value;
        }
    }
}