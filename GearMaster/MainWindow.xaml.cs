namespace GearMaster
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
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
            MainVM      = new MainVM(cadBuilder);
            DataContext = MainVM;
        }

        /// <summary>
        /// Содержит главный класс ViewModel.
        /// </summary>
        public MainVM MainVM { get; private set; }

        /// <summary>
        /// Обработчик события нажатия кнопки построения.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void BuildButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainVM.BuildGearCommand.Execute(sender);
            //LightUpTextBoxesWithIncorrectValues();
            ErrorMessageTextBlock.Text = MainVM.ErrorMessage;
        }

        // /// <summary>
        // /// Подсвечивает текстбоксы в зависимости от корректности введённых данных.
        // /// </summary>
        // public void LightUpTextBoxesWithIncorrectValues()
        // {
        //     var correctBackground   = Brushes.White;
        //     var incorrectBackground = Brushes.PaleVioletRed;
        //
        //     if (MainVM.ParametersCorrectness[ParameterType.OuterRadius])
        //     {
        //         OuterRadius.Background = correctBackground;
        //     }
        //     else
        //     {
        //         OuterRadius.Background = incorrectBackground;
        //     }
        //
        //     if (MainVM.ParametersCorrectness[ParameterType.HoleRadius])
        //     {
        //         HoleRadius.Background = correctBackground;
        //     }
        //     else
        //     {
        //         OuterRadius.Background = incorrectBackground;
        //     }
        //
        //     if (MainVM.ParametersCorrectness[ParameterType.Thickness])
        //     {
        //         Thickness.Background = correctBackground;
        //     }
        //     else
        //     {
        //         Thickness.Background = incorrectBackground;
        //     }
        //
        //     if (MainVM.ParametersCorrectness[ParameterType.ToothHeight])
        //     {
        //         ToothHeight.Background = correctBackground;
        //     }
        //     else
        //     {
        //         ToothHeight.Background = incorrectBackground;
        //     }
        //
        //     if (MainVM.ParametersCorrectness[ParameterType.ToothCount])
        //     {
        //         ToothCount.Background = correctBackground;
        //     }
        //     else
        //     {
        //         ToothCount.Background = incorrectBackground;
        //     }
        // }
    }
}