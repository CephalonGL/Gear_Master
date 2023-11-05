using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace ViewModel
{
    /// <summary>
    /// Хранит информацию о значении всех параметров моделируемого объекта.
    /// </summary>
    [ObservableObject]
    public class ParametersVM
    {
        /// <summary>
        /// Параметры шестерни.
        /// </summary>
        [field: ObservableProperty]
        public  GearParameters Parameters { get; set; }
    }
}