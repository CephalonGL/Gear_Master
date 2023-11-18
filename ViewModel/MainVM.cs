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
        private MainVM()
        {
            Project = new Project();
            BuildCommand = new RelayCommand(() => Project.Build(CrossValidator.AssertCorrect(Project.Parameters)));
        }
        
        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        public RelayCommand BuildCommand;
    }
}