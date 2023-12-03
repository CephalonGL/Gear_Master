namespace Model
{
    /// <summary>
    /// Реализует построение модели шестерни в CAD.
    /// </summary>
    public interface ICadBuilder
    {
        /// <summary>
        /// Выполняет построение шестерни.
        /// </summary>
        /// <param name = "gearParameters">Параметры шестерни.</param>
        void BuildGear(GearParameters gearParameters);
    }
}