namespace Model
{
    using System;

    /// <summary>
    /// Типы параметров.
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// Внешний радиус шестерни по вершинам, мм.
        /// </summary>
        OuterRadius,
        
        /// <summary>
        /// Радиус отверстия, мм.
        /// </summary>
        HoleRadius,
        
        /// <summary>
        /// Толщина шестерни, мм.
        /// </summary>
        Thickness,
        
        /// <summary>
        /// Количество зубьев.
        /// </summary>
        ToothCount,
        
        /// <summary>
        /// Высота зуба.
        /// </summary>
        ToothHeight
    }
}