namespace ViewModel
{
    using CommunityToolkit.Mvvm.Input;
    using Model;

    /// <summary>
    /// Главный класс ViewModel. Хранит информацию о всём проекте.
    /// </summary>
    public class MainVM
    {
        /// <summary>
        /// Конструктро без параметров.
        /// </summary>
        public MainVM()
        {
            Project = new Project();

            BuildCommand =
                new RelayCommand(() =>
                                     Project.Build(Validator
                                                      .AssertOnCorrect(Project.Parameters)));
        }

        /// <summary>
        /// Проект модели.
        /// </summary>
        public Project Project { get; private set; }

        /// <summary>
        /// Параметры шестерни
        /// </summary>
        public GearParametersVM GearParametersVM { get; set; }

        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        public RelayCommand BuildCommand { get; private set; }
    }
}