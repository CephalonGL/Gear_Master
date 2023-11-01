using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace ViewModel
{
    [ObservableObject]
    public class ParametersVM
    {
        [field: ObservableProperty]
        public  Dictionary<ParameterType, ParameterVM> Parameters { get; set; }
    }
}