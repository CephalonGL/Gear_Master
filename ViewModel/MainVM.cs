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

            ParametersCorrectness = new Dictionary<ParameterType, bool>()
                                    {
                                        { ParameterType.OuterRadius, true },
                                        { ParameterType.HoleRadius, true },
                                        { ParameterType.Thickness, true },
                                        { ParameterType.ToothHeight, true },
                                        { ParameterType.ToothCount, true }
                                    };
        }

        /// <summary>
        /// Проект модели.
        /// </summary>
        private Project Project { get; set; }

        /// <summary>
        /// Отображает корректность введённых параметров
        /// </summary>
        public Dictionary<ParameterType, bool> ParametersCorrectness { get; private set; }

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
        /// <returns>True, если валидация прошла успешно, иначе - false.</returns>
        private bool ValidateParameters()
        {
            var validationResult = Validator.IsParametersCorrect(ParametersVm);

            ParametersCorrectness[ParameterType.OuterRadius] =
                validationResult.ParametersCorrectness[ParameterType.OuterRadius];

            ParametersCorrectness[ParameterType.HoleRadius] =
                validationResult.ParametersCorrectness[ParameterType.HoleRadius];

            ParametersCorrectness[ParameterType.Thickness] =
                validationResult.ParametersCorrectness[ParameterType.Thickness];

            ParametersCorrectness[ParameterType.ToothHeight] =
                validationResult.ParametersCorrectness[ParameterType.ToothHeight];

            ParametersCorrectness[ParameterType.ToothCount] =
                validationResult.ParametersCorrectness[ParameterType.ToothCount];

            ErrorMessage = string.Empty;
            if (validationResult.errorMessages.Count > 0)
            {
                for (int i = 0; i < validationResult.errorMessages.Count; i++)
                {
                    ErrorMessage += $"{validationResult.errorMessages[i]}\n";
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        public RelayCommand BuildGearCommand => new RelayCommand(BuildGear);

        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        private void BuildGear()
        { 
            if (ValidateParameters())
            {
                Project.BuildGear(ParametersVm.ExportParameters());
            }
        }
    }
}