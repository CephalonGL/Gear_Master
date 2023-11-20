namespace AutoCADConnector
{
    using Autodesk.AutoCAD.Runtime;
    using GearMaster;

    public class Connector
    {
        /// <summary>
        /// Запускает плагин из AutoCAD.
        /// </summary>
        [CommandMethod("GearMaster")]
        public void StartGearMaster()
        {
            var window = new MainWindow();
            window.Show();
        }
    }
}