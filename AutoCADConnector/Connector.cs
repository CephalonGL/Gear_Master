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

    public class Connector : ICadBuilder, ICadConnector
    {
        public void StartGearMaster()
        {
        }
        
        public void BuildGear()
        {
        }

        /// <summary>
        /// Выполняет построение шестерни.
        /// </summary>
        /// <param name = "parameters">Параметры шестерни.</param>
        public void BuildGear(GearParameters parameters)
        {
            var document = Application.DocumentManager.MdiActiveDocument;
            var database = document.Database;

            using (var transaction = database.TransactionManager.StartTransaction())
            {
                var blockTable = transaction.GetObject(database.BlockTableId, OpenMode.ForRead)
                    as BlockTable;

                var blockTableRecords =
                    transaction.TransactionManager
                               .GetObject(blockTable[BlockTableRecord.ModelSpace],
                                          OpenMode.ForWrite) as BlockTableRecord;

                var circle = new Circle();
                circle.Radius = 1;
                circle.Center = new Point3d(0, 0, 0);

                blockTableRecords?.AppendEntity(circle);
                transaction.AddNewlyCreatedDBObject(circle, true);
                transaction.Commit();
            }
        }

        /// <summary>
        /// Запускает плагин из AutoCAD.
        /// </summary>
        [CommandMethod("GearMaster")]
        public void ConnectToCad()
        {
            var window = new MainWindow(this);
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