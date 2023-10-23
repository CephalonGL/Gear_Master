using System.Collections.Generic;
using Model;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;

namespace ViewModel
{
    public class MainVM
    {
        private Project _project;

        private RelayCommand BuildCommand;
        
        public List<ParametersVM> Parameters {get; set; }
    }
}