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
        //public RelayCommand ValidationCommand { get; set;}

        public ParameterControl()
        {
            InitializeComponent();
        }
        
        // private void ParameterValueTextBox_OnKeyDown(object sender, KeyEventArgs e)
        // {
        //     if (char.IsLetter((char)e.Key))
        //     {
        //         e.Handled = true;
        //     }
        // }
        // private void ParameterValueTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        // {
        //     var parameter = (ParameterVM)this.DataContext;
        //     parameter.Value = this.ParameterValueTextBox.Text;
        //     ValidationCommand.Execute(sender);
        // }
    }
}