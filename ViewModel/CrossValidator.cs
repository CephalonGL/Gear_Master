using System;
using System.Collections.Generic;
using CommunityToolkit.Diagnostics;
using Model;

namespace ViewModel
{
    /// <summary>
    /// Осуществляет перекрёстную валидацию между параметрами.
    /// </summary>
    public static class CrossValidator
    {
        /// <summary>
        /// Выполняет проверку зависимых параметров шестерни.
        /// </summary>
        /// <param name="dependentParameters">Параметры шестерни.</param>
        /// <returns></returns>
        public static GearParameters AssertCorrect(GearParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}