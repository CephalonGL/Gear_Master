namespace ViewModel
{
    using System;
    using System.Collections.Generic;
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
            Project      = new Project(builder);
            ParametersVm = new ParametersVM();
        }

        /// <summary>
        /// Проект модели.
        /// </summary>
        private Project Project { get; set; }

        /// <summary>
        /// Отображает корректность введённых параметров
        /// </summary>
        public Dictionary<ParameterType, bool> IsParametersCorrect { get; private set; }

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
            var validationResult = Validator.IsParametersCorrect(ParametersVm);

            IsParametersCorrect[ParameterType.OuterRadius] =
                validationResult.isParametersCorrect[ParameterType.OuterRadius];

            IsParametersCorrect[ParameterType.HoleRadius] =
                validationResult.isParametersCorrect[ParameterType.HoleRadius];

            IsParametersCorrect[ParameterType.Thickness] =
                validationResult.isParametersCorrect[ParameterType.Thickness];

            IsParametersCorrect[ParameterType.ToothHeight] =
                validationResult.isParametersCorrect[ParameterType.ToothHeight];

            IsParametersCorrect[ParameterType.ToothCount] =
                validationResult.isParametersCorrect[ParameterType.ToothCount];

            if (validationResult.isParametersCorrect[ParameterType.OuterRadius]    == false
                || validationResult.isParametersCorrect[ParameterType.HoleRadius]  == false
                || validationResult.isParametersCorrect[ParameterType.Thickness]   == false
                || validationResult.isParametersCorrect[ParameterType.ToothHeight] == false
                || validationResult.isParametersCorrect[ParameterType.ToothCount]  == false)
            {
                IsAbleToBuild = false;
            }

            if (validationResult.errorMessages.Count > 0)
            {
                foreach (var errorMessage in validationResult.errorMessages)
                {
                    ErrorMessage += $"{validationResult.errorMessages}\n";
                }
            }
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