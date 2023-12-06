namespace ViewModel
{
    using System;
    using System.Windows.Input;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using Model;

    /// <summary>
    /// Главный класс ViewModel. Хранит информацию о всём проекте.
    /// </summary>
    public class MainVM
    {
        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public MainVM(ICadBuilder builder)
        {
            Project = new Project(builder);
        }

        /// <summary>
        /// Проект модели.
        /// </summary>
        private Project Project { get; set; }

        /// <summary>
        /// Флаг, отображающий возможность выполнения построения модели.
        /// </summary>
        public bool IsAbleToBuild { get; private set; }
        
        /// <summary>
        /// Хранит сообщение об ошибке валидации.
        /// </summary>
        public string ErrorMessage { get; private set; }


        /// <summary>
        /// Параметры шестерни
        /// </summary>
        public ParametersVM ParametersVm { get; set; }

        /// <summary>
        /// Выполняет проверку пользовательского ввода.
        /// </summary>
        public void ValidateParameters()
        {
            var validationResult = Validator.CheckCorrect(ParametersVm);

            IsAbleToBuild = validationResult.isAbleToBuild;
            ErrorMessage  = validationResult.errorMessage;
        }
        
        /// <summary>
        /// Выполняет проверку пользовательского ввода.
        /// </summary>
        public RelayCommand ValidateParametersCommand => new RelayCommand(ValidateParameters);

        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        public RelayCommand BuildGearCommand => new RelayCommand(BuildGear);

        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        private void BuildGear()
        {
            Project.BuildGear();
        }
    }
}