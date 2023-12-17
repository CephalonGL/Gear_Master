namespace AutoCadConnector
{
    using System;
    using Autodesk.AutoCAD.Runtime;
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Geometry;

    public class CircleArray
    {
        static Point2d PolarPoints(Point2d pPt, double dAng, double dDist)
        {
            return new Point2d(pPt.X + (dDist * Math.Cos(dAng)),
                               pPt.Y + (dDist * Math.Sin(dAng)));
        }

        [CommandMethod("PolarArrayObject")]
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
    }
}