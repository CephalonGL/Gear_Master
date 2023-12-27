namespace GearMaster
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using CommunityToolkit.Mvvm.Input;
    using Logger;
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

            OuterRadiusParameter.DataContext =
                MainVM.ParametersVM.Parameters[ParameterType.OuterRadius];

            HoleRadiusParameter.DataContext =
                MainVM.ParametersVM.Parameters[ParameterType.HoleRadius];

            ThicknessParameter.DataContext =
                MainVM.ParametersVM.Parameters[ParameterType.Thickness];

            ToothHeightParameter.DataContext =
                MainVM.ParametersVM.Parameters[ParameterType.ToothHeight];

            ToothCountParameter.DataContext =
                MainVM.ParametersVM.Parameters[ParameterType.ToothCount];

            ParameterTextBoxes = new Dictionary<ParameterType, ParameterControl>
                                 {
                                     { ParameterType.OuterRadius, OuterRadiusParameter },
                                     { ParameterType.HoleRadius, HoleRadiusParameter },
                                     { ParameterType.Thickness, ThicknessParameter },
                                     { ParameterType.ToothHeight, ToothHeightParameter },
                                     { ParameterType.ToothCount, ToothCountParameter }
                                 };
        }

        /// <summary>
        /// Хранит типы параметров для элементов управления.
        /// </summary>
        private Dictionary<ParameterType, ParameterControl> ParameterTextBoxes;

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
            FileLogger.Log($"Вызван обработчик {nameof(BuildButton_OnClick)}.");
            MainVM.BuildGearCommand.Execute(sender);
            LightUpTextBoxesWithIncorrectValues();
            ErrorMessageTextBlock.Text = MainVM.ErrorMessage;
        }

        /// <summary>
        /// Подсвечивает текстбоксы в зависимости от корректности введённых данных.
        /// </summary>
        private void LightUpTextBoxesWithIncorrectValues()
        {
            var correctBackground   = Brushes.White;
            var incorrectBackground = Brushes.LightCoral;

            foreach (var parameterCorrectness in MainVM.ParametersVM.ParametersCorrectness)
            {
                var parameterControl   = ParameterTextBoxes[parameterCorrectness.Key];
                var isParameterCorrect = parameterCorrectness.Value;

                parameterControl.ParameterValueTextBox.Background =
                    isParameterCorrect ? correctBackground : incorrectBackground;
            }
        }
    }
}