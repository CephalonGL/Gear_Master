namespace GearMaster
{
    using System.Windows;
    using System.Windows.Input;
    using CommunityToolkit.Mvvm.Input;
    using Model;
    using ViewModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Инициализирует главное окно программы.
        /// </summary>
        public MainWindow(ICadBuilder cadBuilder)
        {
            InitializeComponent();
            MainVM           = new MainVM(cadBuilder);
            this.DataContext = MainVM;
        }

        /// <summary>
        /// Содержит главный класс ViewModel.
        /// </summary>
        public MainVM MainVM { get; private set; }
    }
}