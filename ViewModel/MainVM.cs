using System.Collections.Generic;
using Model;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;

namespace ViewModel
{
    public class MainVM
    {
        private Project _project;

        public Project Project
        {
            get => _project; 
            private set => _project = value;
        }

        MainVM()
        {
            Project = new Project();
        }
        
        public RelayCommand BuildCommand;
        
        public List<ParametersVM> Parameters {get; set; }
    }
}