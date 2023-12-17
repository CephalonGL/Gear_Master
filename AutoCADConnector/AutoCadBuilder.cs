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
            var outerRadius = gearParameters.outerRadius;
            var holeRadius  = gearParameters.holeRadius;
            var thickness   = gearParameters.thickness;
            var toothHeight = gearParameters.toothHeight;
            var innerRadius = outerRadius - toothHeight;
            var toothCount  = gearParameters.toothCount;
            var toothWidth  = Math.PI * innerRadius / toothCount;

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

                    var gearBody = CreateCircle(gearCenter, innerRadius);

                    //Создание тела шестерни по внешнему радиусу.
                    var gear = new Solid3d();
                    gear.Extrude(gearBody, thickness, 0);

                    //Создание массива зубьев.
                    var toothSketch = CreateRectangle(2 * toothHeight,
                                                      toothWidth,
                                                      new Point3d(0, innerRadius, 0));

                    for (var i = 0; i < toothCount; i++)
                    {
                        var toothClone = toothSketch.Clone() as Entity;

                        var rotationAngle = 2 * i * Math.PI / toothCount;

                        toothClone.TransformBy(Matrix3d.Rotation(rotationAngle,
                                                                 Vector3d.ZAxis,
                                                                 gearCenter));

                        var curves = new DBObjectCollection();
                        curves.Add(toothClone as Region);
                        var regions = Region.CreateFromCurves(curves);
                        var region  = (Region)regions[0];

                        var tooth = new Solid3d();
                        tooth.Extrude(region, -thickness, 0);

                        gear.BooleanOperation(BooleanOperationType.BoolUnite, tooth);
                    }

                    //Создание отверстия.
                    var holeCircle = CreateCircle(new Point3d(0, 0, 0), holeRadius);
                    var hole       = new Solid3d();
                    hole.Extrude(holeCircle, thickness, 0);
                    gear.BooleanOperation(BooleanOperationType.BoolSubtract, hole);

                    //Фиксация изменений.
                    blockTableRecords?.AppendEntity(gear);
                    transaction.AddNewlyCreatedDBObject(gear, true);
                    transaction.Commit();
                }
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