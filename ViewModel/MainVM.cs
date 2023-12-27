namespace ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
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
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            ParametersVM               = new ParametersVM();
            Builder                    = builder;
        }

        /// <summary>
        /// Построитель.
        /// </summary>
        private ICadBuilder Builder { get; set; }

        /// <summary>
        /// Хранит сообщение об ошибке валидации.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Параметры шестерни
        /// </summary>
        public ParametersVM ParametersVM { get; set; }

        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        public RelayCommand BuildGearCommand => new RelayCommand(BuildGear);
        
        /// <summary>
        /// Запускает валидацию параметров.
        /// </summary>
        public RelayCommand ValidationCommand => new RelayCommand(ValidateParameters);

        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        private void BuildGear()
        {
            var validationResult = ParametersVM.ValidateParameters();
            ErrorMessage = validationResult.errorMessage;

            if (validationResult.isCorrect)
            {
                Builder.BuildGear(ParametersVM.ExportParameters());
            }
        }
        
        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        private void ValidateParameters()
        {
            var validationResult = ParametersVM.ValidateParameters();
            ErrorMessage = validationResult.errorMessage;

            if (validationResult.isCorrect)
            {
                Builder.BuildGear(ParametersVM.ExportParameters());
            }
        }
    }
}