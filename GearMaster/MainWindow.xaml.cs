namespace GearMaster
{
    using System.Collections.Generic;
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

            ParameterControls = new Dictionary<ParameterType, ParameterControl>
                                {
                                    { ParameterType.OuterRadius, OuterRadiusParameter },
                                    { ParameterType.HoleRadius, HoleRadiusParameter },
                                    { ParameterType.Thickness, ThicknessParameter },
                                    { ParameterType.ToothHeight, ToothHeightParameter },
                                    { ParameterType.ToothCount, ToothCountParameter }
                                };

            foreach (var parameterControl in ParameterControls)
            {
                parameterControl.Value.DataContext =
                    MainVM.ParametersVM.Parameters[parameterControl.Key];

                parameterControl.Value.ParameterValueTextBox.TextChanged +=
                    Parameter_OnValueChanged;
            }
        }

        /// <summary>
        /// Хранит типы параметров для элементов управления.
        /// </summary>
        private Dictionary<ParameterType, ParameterControl> ParameterControls;

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
            MainVM.BuildGear();
        }

        /// <summary>
        /// Обработчик события изменения параметра.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void Parameter_OnValueChanged(object sender, TextChangedEventArgs e)
        {
            ValidateParameters();
        }

        /// <summary>
        /// Проводит валидацию параметров.
        /// </summary>
        private void ValidateParameters()
        {
            MainVM.ParametersVM.ValidateParameters();
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
                var parameterControl   = ParameterControls[parameterCorrectness.Key];
                var isParameterCorrect = parameterCorrectness.Value;

                parameterControl.ParameterValueTextBox.Background =
                    isParameterCorrect ? correctBackground : incorrectBackground;
            }
        }
    }
}