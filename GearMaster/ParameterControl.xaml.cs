namespace GearMaster
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;
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