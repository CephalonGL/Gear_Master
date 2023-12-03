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
        /// <summary>
        /// Выполняет построение шестерни.
        /// </summary>
        /// <param name = "gearParameters">Параметры шестерни.</param>
        public void BuildGear(GearParameters gearParameters)
        {
            var document    = Application.DocumentManager.MdiActiveDocument;
            var database    = document.Database;
            var transaction = database.TransactionManager.StartTransaction();

            //var outerRadius = double.Parse(gearParameters.OuterRadius.Value);
            //var holeRadius  = double.Parse(gearParameters.HoleRadius.Value);
            //var thickness   = double.Parse(gearParameters.Thickness.Value);
            //var toothHeight = double.Parse(gearParameters.ToothHeight.Value);
            //var toothCount  = int.Parse(gearParameters.ToothCount.Value);

            var outerRadius = 100;
            var holeRadius  = 50;
            var thickness   = 10;
            var toothHeight = 5;
            var toothCount  = 10;

            using (transaction)
            {
                var blockTable = transaction.GetObject(database.BlockTableId, OpenMode.ForRead)
                    as BlockTable;

                var blockTableRecords =
                    transaction.TransactionManager
                               .GetObject(blockTable[BlockTableRecord.ModelSpace],
                                          OpenMode.ForWrite) as BlockTableRecord;

                //Скетч для внешнего радиуса.
                var circle = new Circle();
                circle.Radius = outerRadius;

                var centerPoint = new Point3d(0, 0, 0);
                circle.Center = centerPoint;

                blockTableRecords?.AppendEntity(circle);
                transaction.AddNewlyCreatedDBObject(circle, true);
                transaction.Commit();
            }
        }

        public void BuildDefaultCircle()
        {
            var document    = Application.DocumentManager.MdiActiveDocument;
            var database    = document.Database;
            var transaction = database.TransactionManager.StartTransaction();

            using (transaction)
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