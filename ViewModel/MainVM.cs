using System.Collections.Generic;
using Model;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;

namespace ViewModel
{
    /// <summary>
    /// Главный класс ViewModel. Хранит информацию о всём проекте.
    /// </summary>
    public class MainVM
    {
        /// <summary>
        /// Хранит проект.
        /// </summary>
        public Project Project { get; private set; }

        /// <summary>
        /// Конструктро без параметров.
        /// </summary>
        MainVM()
        {
            Project = new Project();
        }
        
        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        public RelayCommand BuildCommand;
        
        /// <summary>
        /// Хранит все параметры моделируемого изделия.
        /// </summary>
        public ParametersVM ParametersVM {get; set; }
    }
}