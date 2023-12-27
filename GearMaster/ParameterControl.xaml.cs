namespace GearMaster
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using CommunityToolkit.Mvvm.Input;
    using ViewModel;

    public partial class ParameterControl : UserControl
    {
        public ParameterControl(ParameterVM parameter)
        {
            InitializeComponent();
            DataContext = parameter;
        }

        public ParameterControl()
        {
            InitializeComponent();
        }
    }
}