namespace ViewModel
{
    using System;
    using CommunityToolkit.Mvvm.Input;
    using Model;

    /// <summary>
    /// Представление для параметров шестерни в VM.
    /// </summary>
    public class GearParametersVM
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="parameters">Параметры шестерни.</param>
        public GearParametersVM(GearParameters parameters)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// Хранит парамеры шестерни.
        /// </summary>
        public GearParameters Parameters { get; private set; }

        /// <summary>
        /// Выполняет валидацию параметров.
        /// </summary>
        /// <returns></returns>
        public (bool, string) ValidateParameters()
        {
            throw new NotImplementedException();
        }
    }
}