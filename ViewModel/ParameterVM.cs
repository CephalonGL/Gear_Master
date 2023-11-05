using System;
using Model;

namespace ViewModel
{
    /// <summary>
    /// Хранит информацию об одном из параметров моделируемого объекта.
    /// </summary>
    public class ParameterVM
    {
        ParameterVM(ParameterType parameterType)
        {
            ParameterType = parameterType;
        }
        
        /// <summary>
        /// Хранит информацию о параметре.
        /// </summary>
        public Parameter Parameter { get; set; }
        
        public ParameterType ParameterType { get; private set;}

        
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}