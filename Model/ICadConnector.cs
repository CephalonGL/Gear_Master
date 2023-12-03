namespace Model
{
    /// <summary>
    /// Реализует подключение и отключение от САПР.
    /// </summary>
    public interface ICadConnector
    {
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