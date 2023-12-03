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
        /// Параметры шестерни
        /// </summary>
        public GearParametersVM GearParametersVM { get; set; }

        /// <summary>
        /// Выполняет проверку параметров.
        /// </summary>
        /// <returns></returns>
        public GearParameters AssertParametersCorrect()
        {
            return new GearParameters();
        }

        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        public RelayCommand BuildCommand => new RelayCommand(BuildGearCommand);

        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        private void BuildGearCommand()
        {
            Project.BuildGear();
        }
    }
}