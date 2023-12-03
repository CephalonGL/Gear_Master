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
            //BuildButton.Command = buildCommand;
            MainVM                 = new MainVM();
            MainVM.Project.Builder = cadBuilder;
            cadBuilder.BuildGear(MainVM.GearParametersVM.Parameters);
        }
        
        /// <summary>
        /// Содержит главный класс ViewModel.
        /// </summary>
        public MainVM MainVM { get; private set; }
    }
}