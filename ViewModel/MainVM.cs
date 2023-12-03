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
        /// Конструктор без параметров.
        /// </summary>
        public MainVM()
        {
            Project  = new Project();
            ValidateParameters = this.GearParametersVM.
        }

        /// <summary>
        /// Флаг, отображающий возможность выполнения построения модели.
        /// </summary>
        public bool IsAbleToBuild { get; private set; }

        /// <summary>
        /// Проект модели.
        /// </summary>
        public Project Project { get; private set; }

        /// <summary>
        /// Параметры шестерни
        /// </summary>
        public GearParametersVM GearParametersVM { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RelayCommand ValidateParameters { get; private set; }
        
        /// <summary>
        /// Команда построения модели в САПР.
        /// </summary>
        public RelayCommand BuildCommand { get; private set; }
    }
}