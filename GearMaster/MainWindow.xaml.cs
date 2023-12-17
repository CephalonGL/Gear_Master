namespace GearMaster
{
    using System.Windows;
    using System.Windows.Controls;
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

            OuterRadius.Text = MainVM.ParametersVm.OuterRadius;
            HoleRadius.Text  = MainVM.ParametersVm.HoleRadius;
            Thickness.Text   = MainVM.ParametersVm.Thickness;
            ToothHeight.Text = MainVM.ParametersVm.ToothHeight;
            ToothCount.Text  = MainVM.ParametersVm.ToothCount;
        }

        /// <summary>
        /// Содержит главный класс ViewModel.
        /// </summary>
        public MainVM MainVM { get; private set; }

        /// <summary>
        /// Обработчик события изменения внешнего радиуса.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void OuterRadius_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MainVM.ParametersVm.OuterRadius = OuterRadius.Text;
        }

        /// <summary>
        /// Обработчик события изменения радиуса отверстия.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void HoleRadius_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MainVM.ParametersVm.OuterRadius = HoleRadius.Text;
        }

        /// <summary>
        /// Обработчик события изменения толщины.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void Thickness_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MainVM.ParametersVm.OuterRadius = Thickness.Text;
        }

        /// <summary>
        /// Обработчик события изменения высоты зуба.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToothHeight_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MainVM.ParametersVm.OuterRadius = ToothHeight.Text;
        }

        /// <summary>
        /// Обработчик события изменения количества зубьев.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToothCount_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MainVM.ParametersVm.OuterRadius = ToothCount.Text;
        }
    }
}