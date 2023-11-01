using System;
using Model;

namespace ViewModel
{
    /// <summary>
    /// Хранит информацию об одном из параметров моделируемого объекта.
    /// </summary>
    public class ParameterVM
    {
        /// <summary>
        /// Хранит информацию о параметре.
        /// </summary>
        public Parameter Parameter { get; set; }

        
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}