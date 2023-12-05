namespace AutoCADConnector
{
    using System;
    using System.Windows.Input;
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Geometry;
    using Autodesk.AutoCAD.Runtime;
    using GearMaster;
    using Model;
    using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

    public class AutoCadConnector : ICadConnector
    {
        /// <summary>
        /// Запускает плагин из AutoCAD.
        /// </summary>
        [CommandMethod("GearMaster")]
        public void ConnectToCad()
        {
            var autoCadBuilder = new AutoCadBuilder();
            var window         = new MainWindow(autoCadBuilder);
            window.Show();
        }

        /// <summary>
        /// Отключиться от САПР.
        /// </summary>
        public void DisconnectFromCad()
        {
        }
    }
}