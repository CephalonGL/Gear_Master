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
        /// <param name = "parameters">Параметры шестерни.</param>
        void BuildGear(GearParameters parameters);

        /// <summary>
        /// Подключитья к выбранной САПР.
        /// </summary>
        void ConnectToCad();

        /// <summary>
        /// Отключиться от САПР.
        /// </summary>
        void DisconnectFromCad();
    }
}