namespace ViewModel
{
    using System;
    using System.Collections.Generic;
    using CommunityToolkit.Mvvm.Input;
    using Model;

    /// <summary>
    /// Представление для параметров шестерни в VM.
    /// </summary>
    public class ParametersVM
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="parameters">Параметры шестерни.</param>
        public ParametersVM(Dictionary<ParameterType, Parameter> parameters)
        {
            ParameterVMs = new Dictionary<ParameterType, ParameterVM>
                           {
                               {
                                   ParameterType.OuterRadius,
                                   new ParameterVM(double.Parse(parameters.OuterRadius))
                               },
                               { ParameterType.HoleRadius, new ParameterVM() },
                               { ParameterType.Thickness, new ParameterVM() },
                               { ParameterType.ToothHeight, new ParameterVM() },
                               { ParameterType.ToothCount, new ParameterVM() }
                           };
        }

        /// <summary>
        /// Хранит парамеры шестерни.
        /// </summary>
        public Dictionary<ParameterType, ParameterVM> ParameterVMs { get; private set; }
    }
}