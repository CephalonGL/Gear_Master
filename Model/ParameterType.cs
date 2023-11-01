namespace Model
{
    /// <summary>
    /// Отображает различные типы параметров моделируемого объекта.
    /// Значения всех параметров указываются в системе СИ.
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// Внешний диаметр шестерни в миллиметрах.
        /// </summary>
        OuterDiameter,
        /// <summary>
        /// Диаметр отверстия в шестерне в миллиметрах.
        /// </summary>
        HoleDiameter,
        /// <summary>
        /// Толщина шестерни в миллиметрах.
        /// </summary>
        Thickness,
        /// <summary>
        /// Количество зубъев шестерни в штуках.
        /// </summary>
        ToothCount,
        /// <summary>
        /// Высота зуба в миллиметрах.
        /// </summary>
        ToothHeight
    }
}