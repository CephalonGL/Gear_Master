namespace ViewModel
{
    using System.Windows;
    using CommunityToolkit.Mvvm;
    using CommunityToolkit.Mvvm.ComponentModel;
    using Model;

    /// <summary>
    /// Представление параметра.
    /// </summary>
    public class ParameterVM : DependencyObject
    {
        /// <summary>
        /// Параметры.
        /// </summary>
        [ObservableProperty]
        private Parameter _parameter;
        
        /// <summary>
        /// Отображает состояние корректности данных.
        /// </summary>
        public bool IsCorrect { get; private set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public ParameterVM()
        {
        }

        /// <summary>
        /// Параметры.
        /// </summary>
        private Parameter Parameter
        {
            get => _parameter;
            set => _parameter = value;
        }
    }
}