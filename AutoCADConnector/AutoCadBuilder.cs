namespace AutoCadConnector
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
            var outerRadius = 100;
            var holeRadius  = 50;
            var thickness   = 10;
            var toothHeight = 5;
            var toothCount  = 10;

            var document = Application.DocumentManager.MdiActiveDocument;
            var database = document.Database;

            using (var documentLock = document.LockDocument())
            {
                using (var transaction = database.TransactionManager.StartTransaction())
                {
                    var blockTable = transaction.GetObject(database.BlockTableId, OpenMode.ForRead)
                        as BlockTable;

                    var blockTableRecords =
                        transaction.TransactionManager
                                   .GetObject(blockTable[BlockTableRecord.ModelSpace],
                                              OpenMode.ForWrite) as BlockTableRecord;

                    var gearCenter = new Point3d(0, 0, 0);

                    var gearBody = CreateCircle(gearCenter, outerRadius);

                    //Создание тела шестерни по внешнему радиусу.
                    var gear = new Solid3d();
                    gear.Extrude(gearBody, thickness, 0);

                    //Создание отверстия.
                    var holeCircle = CreateCircle(new Point3d(0, 0, 0), holeRadius);
                    var hole       = new Solid3d();
                    hole.Extrude(holeCircle, thickness, 0);
                    gear.BooleanOperation(BooleanOperationType.BoolSubtract, hole);

                    //Создание зубьев.
                    var toothSketch = CreateRectangle(10, 10, new Point3d(0, outerRadius, 0));

                    for (var i = 0; i < toothCount; i++)
                    {
                        var toothClone = toothSketch.Clone() as Entity;

                        var rotationAngle = i * Math.PI / toothCount;

                        toothClone.TransformBy(Matrix3d.Rotation(rotationAngle, Vector3d.ZAxis,
                                                                 gearCenter));

                        var curves = new DBObjectCollection();
                        curves.Add(toothClone as Region);
                        var regions = Region.CreateFromCurves(curves);
                        var region  = (Region)regions[0];

                        var tooth = new Solid3d();
                        tooth.Extrude(region, thickness, 0);

                        gear.BooleanOperation(BooleanOperationType.BoolUnite, tooth);
                    }

                    blockTableRecords?.AppendEntity(gear);
                    transaction.AddNewlyCreatedDBObject(gear, true);
                    transaction.Commit();
                }
            }
        }

        private static Point2d PolarPoints(Point2d point, double dAngle, double dDistance)
        {
            return new Point2d(point.X + (dDistance * Math.Cos(dAngle)),
                               point.Y + (dDistance * Math.Sin(dAngle)));
        }

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

                        var dDistance = point2dArrayBase.GetDistanceTo(PointObjectBase);

                        var dAngleFromX =
                            point2dArrayBase.GetVectorTo(PointObjectBase).Angle;

                        var point2dTo = PolarPoints(point2dArrayBase,
                                                    (nCount * dAngle) + dAngleFromX,
                                                    dDistance);

                        var vector2d = PointObjectBase.GetVectorTo(point2dTo);
                        var vector3d = new Vector3d(vector2d.X, vector2d.Y, 0);
                        EntityClone.TransformBy(Matrix3d.Displacement(vector3d));

                        // The following code demonstrates how to rotate each object like
                        // the ARRAY command does.
                        extents3d = EntityClone.Bounds.GetValueOrDefault();

                        PointObjectBase = new Point2d(extents3d.MinPoint.X,
                                                      extents3d.MaxPoint.Y);

                        // Rotate the cloned entity around its upper-left extents point
                        var curUCSMatrix = document.Editor.CurrentUserCoordinateSystem;
                        var curUCS       = curUCSMatrix.CoordinateSystem3d;

                        EntityClone.TransformBy(Matrix3d.Rotation(nCount * dAngle,
                                                                      curUCS.Zaxis,
                                                                      new Point3d(PointObjectBase.X,
                                                                          PointObjectBase.Y,
                                                                          0)));

                        blockTableRecord.AppendEntity(EntityClone);
                        transaction.AddNewlyCreatedDBObject(EntityClone, true);

                        nCount++;
                    }
                }

                // Save the new objects to the database
                transaction.Commit();
            }
        }

        private Region CreateCircle(Point3d center, double radius)
        {
            var circle = new Circle(center, Vector3d.ZAxis, radius);

            var curves = new DBObjectCollection();
            curves.Add(circle);
            var regions = Region.CreateFromCurves(curves);
            var region  = (Region)regions[0];

            return region;
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
        /// Создает эскиз в виде прямоугольника.
        /// </summary>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="length">Длина прямоугольника.</param>
        /// <param name="center">Центр прямоугольника.</param>
        /// <returns>Прямоугольник.</returns>
        public Region CreateRectangle(double  width,
                                      double  length,
                                      Point3d center)
        {
            var polylinePoints = new Point3d[4];

            polylinePoints[0] = new Point3d(center.X - (length / 2),
                                            center.Y - (width  / 2),
                                            center.Z);

            polylinePoints[1] = new Point3d(center.X - (length / 2),
                                            center.Y + (width  / 2),
                                            center.Z);

            polylinePoints[2] = new Point3d(center.X + (length / 2),
                                            center.Y + (width  / 2),
                                            center.Z);

            polylinePoints[3] = new Point3d(center.X + (length / 2),
                                            center.Y - (width  / 2),
                                            center.Z);

            var point3DCollection = new Point3dCollection(polylinePoints);

            var outline = new Polyline3d(Poly3dType.SimplePoly,
                                         point3DCollection,
                                         true);

            var curves = new DBObjectCollection();
            curves.Add(outline);

            var regions = new DBObjectCollection();
            regions = Region.CreateFromCurves(curves);

            var region = (Region)regions[0];

            return region;
        }
    }
}