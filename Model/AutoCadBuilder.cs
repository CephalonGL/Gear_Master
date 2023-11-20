namespace Model
{
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Runtime;

    /// <summary>
    /// Выполняет построение шестерни в САПР Autodesk AutoCAD.
    /// </summary>
    public class AutoCadBuilder : ICadBuilder
    {
        /// <summary>
        /// Деструктор.
        /// </summary>
        ~AutoCadBuilder()
        {
            DisconnectFromCad();
        }

        /// <summary>
        /// Выполняет подкючение к САПР.
        /// </summary>
        public void ConnectToCad()
        {
            return;
        }

        /// <summary>
        /// Выполняет отключение от САПР.
        /// </summary>
        public void DisconnectFromCad()
        {
            return;
        }

        /// <summary>
        /// Выполняет построение шестерни.
        /// </summary>
        /// <param name="parameters">Параметры объекта шестерни.</param>
        [CommandMethod("Demo")]
        public void BuildGear(GearParameters parameters)
        {
            return;
        }

        /// <summary>
        /// Выполняет построение одного зуба.
        /// </summary>
        private void BuildGearTooth()
        {
            return;
        }
    }
}