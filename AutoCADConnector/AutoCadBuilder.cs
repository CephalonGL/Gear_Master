namespace AutoCADConnector
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Geometry;
    using Autodesk.AutoCAD.Runtime;
    using GearMaster;
    using Model;
    using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

    public class AutoCadBuilder : ICadBuilder
    {
        /// <summary>
        /// Выполняет построение шестерни.
        /// </summary>
        /// <param name = "gearParameters">Параметры шестерни.</param>
        public void BuildGear(
            (double outerRadius, double holeRadius, double thickness, double toothHeight, int
                toothCount) gearParameters)
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
        
        private static Point2d PolarPoints(Point2d point, double dAngle, double dDistance)
        {
            return new Point2d(point.X + (dDistance * Math.Cos(dAngle)),
                               point.Y + (dDistance * Math.Sin(dAngle)));
        }
        
        /// <summary>
        /// 
        /// </summary>
        [CommandMethod("TestPolarArray")]
        public static void PolarArrayObject()
        {
            // Get the current document and database
            var document    = Application.DocumentManager.MdiActiveDocument;
            var database    = document.Database;
            var transaction = database.TransactionManager.StartTransaction();

            // Start a transaction
            using (transaction)
            {
                // Open the Block table record for read
                var blockTable = transaction.GetObject(database.BlockTableId,
                                                       OpenMode.ForRead) as BlockTable;

                // Open the Block table record Model space for write
                var blockTableRecord =
                    transaction.GetObject(blockTable[BlockTableRecord.ModelSpace],
                                          OpenMode.ForWrite) as BlockTableRecord;

                // Create a circle that is at 2,2 with a radius of 1
                using (var circle = new Circle())
                {
                    circle.Center = new Point3d(2, 2, 0);
                    circle.Radius = 1;

                    // Add the new object to the block table record and the transaction
                    blockTableRecord.AppendEntity(circle);
                    transaction.AddNewlyCreatedDBObject(circle, true);

                    // Create a 4 object polar array that goes a 180
                    var nCount = 1;

                    // Set a value in radians for 60 degrees
                    var dAngle = 1.0472;

                    // Use (4,4,0) as the base point for the array
                    var point2dArrayBase = new Point2d(4, 4);

                    while (nCount < 4)
                    {
                        var EntityClone = circle.Clone() as Entity;

                        Extents3d extents3d;
                        Point2d   PointObjectBase;

                        // Typically the upper-left corner of an object's extents is used
                        // for the point on the object to be arrayed unless it is
                        // an object like a circle.
                        var circleArrayObject = EntityClone as Circle;

                        if (circleArrayObject != null)
                        {
                            PointObjectBase = new Point2d(circleArrayObject.Center.X,
                                                          circleArrayObject.Center.Y);
                        }
                        else
                        {
                            extents3d = EntityClone.Bounds.GetValueOrDefault();

                            PointObjectBase = new Point2d(extents3d.MinPoint.X,
                                                          extents3d.MaxPoint.Y);
                        }

                        double dDistance   = point2dArrayBase.GetDistanceTo(PointObjectBase);
                        double dAngleFromX = point2dArrayBase.GetVectorTo(PointObjectBase).Angle;

                        Point2d point2dTo = PolarPoints(point2dArrayBase,
                                                       (nCount * dAngle) + dAngleFromX,
                                                       dDistance);

                        Vector2d vector2d = PointObjectBase.GetVectorTo(point2dTo);
                        Vector3d vector3d = new Vector3d(vector2d.X, vector2d.Y, 0);
                        EntityClone.TransformBy(Matrix3d.Displacement(vector3d));

                        /*
                        // The following code demonstrates how to rotate each object like
                        // the ARRAY command does.
                        acExts = acEntClone.Bounds.GetValueOrDefault();
                        acPtObjBase = new Point2d(acExts.MinPoint.X,
                                                    acExts.MaxPoint.Y);

                        // Rotate the cloned entity around its upper-left extents point
                        Matrix3d curUCSMatrix = acDoc.Editor.CurrentUserCoordinateSystem;
                        CoordinateSystem3d curUCS = curUCSMatrix.CoordinateSystem3d;
                        acEntClone.TransformBy(Matrix3d.Rotation(nCount * dAng,
                                                                    curUCS.Zaxis,
                                                                    new Point3d(acPtObjBase.X,
                                                                                acPtObjBase.Y, 0)));
                        */

                        blockTableRecord.AppendEntity(EntityClone);
                        transaction.AddNewlyCreatedDBObject(EntityClone, true);

                        nCount++;
                    }
                }

                // Save the new objects to the database
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
    }
}