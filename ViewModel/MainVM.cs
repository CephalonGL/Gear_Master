namespace ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Input;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using Logger;
    using Microsoft.Build.Framework;
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
        public void BuildGear()
        {
            var validationResult = ParametersVM.ValidateParameters();
            ErrorMessage = validationResult.errorMessage;

            if (validationResult.isCorrect)
            {
                var exportedParameters = ParametersVM.ExportParameters();

                FileLogger.Log($"Вызван метод построения шестерни "
                               + $"{nameof(MainVM)}.{nameof(BuildGear)}.",
                               this.ParametersVM.Parameters);

                try
                {
                    Builder.BuildGear(exportedParameters);
                    FileLogger.Log("Построение выполнено успешно.");
                }
                catch (Exception exception)
                {
                    FileLogger.Log($"Построение не выполнено. Непредвиденная ошибка.", exception);

                    throw;
                }
            }
            else
            {
                FileLogger.Log($"Валидация провалена при вызове метода "
                               + $"{nameof(MainVM)}.{nameof(BuildGear)}.",
                               this.ParametersVM.Parameters);
            }
        }
    }
}