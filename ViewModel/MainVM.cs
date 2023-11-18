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
        private MainVM()
        {
            Project = new Project();

            BuildCommand =
                new RelayCommand(() =>
                                     Project.Build(CrossValidator
                                                      .AssertCorrect(Project.Parameters)));
        }

        /// <summary>
        /// Хранит проект.
        /// </summary>
        public Project Project { get; private set; }


        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        public RelayCommand BuildCommand { get; private set; }
    }
}