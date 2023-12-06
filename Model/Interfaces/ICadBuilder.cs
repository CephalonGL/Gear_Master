namespace Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Реализует построение модели шестерни в CAD.
    /// </summary>
    public interface ICadBuilder
    {
        /// <summary>
        /// Выполняет построение шестерни.
        /// </summary>
        /// <param name = "gearParameters">Параметры шестерни.</param>
        void BuildGear((
            double outerRadius,
            double holeRadius,
            double thickness,
            double toothHeight,
            int toothCount) gearParameters);
    }
}