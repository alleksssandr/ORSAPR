using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;


namespace Motor
{
    /// <summary>
    /// Класс отвечающий за корпус мотора
    /// </summary>
    class Box : IPart
    {
        
        #region 

        /// <summary>
        /// диаметр корпуса
        /// </summary>
        private int _diameretBox;
        
        /// <summary>
        /// длина корпуса 
        /// </summary>
        private int _lenBox; 
      
        #endregion

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parameters">Класс с параметрами построения мотора</param>
        public Box(MotorParameters parameters)
        {
            _diameretBox = parameters.DiameretBox;
            _lenBox      = parameters.LenBox;
        }

        /// <summary>
        /// Функция построения корпуса мотора
        /// </summary>
        /// <param name="database">База данных</param>
        /// <param name="trans">Транцакция</param>
        /// <param name="parameters">Класс с параметрами построения мотора</param>
        public void Build(Database database, Transaction trans, MotorParameters parameters)
        {
            int lenBox      = _lenBox;
            int diameretBox = _diameretBox;

            // Open the Block table record for read
            BlockTable acBlkTbl = trans.GetObject(database.BlockTableId, OpenMode.ForRead) as BlockTable;

            // Open the Block table record Model space for write
            BlockTableRecord acBlkTblRec = trans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

            Solid3d box = new Solid3d();
            box.SetDatabaseDefaults();
            box.CreateFrustum(lenBox, diameretBox / 2, diameretBox / 2, diameretBox / 2);
            box.ColorIndex = 4;

            // Add the new object to the block table record and the transaction
            acBlkTblRec.AppendEntity(box);
            trans.AddNewlyCreatedDBObject(box, true);

            ObjectId[] ids = new ObjectId[] { box.ObjectId };

            SubentityId subentId = new SubentityId(SubentityType.Null, IntPtr.Zero);

            FullSubentityPath path = new FullSubentityPath(ids, subentId);

            List<SubentityId> subentIds = new List<SubentityId>();
            DoubleCollection radii = new DoubleCollection();
            DoubleCollection startSetback = new DoubleCollection();
            DoubleCollection endSetback = new DoubleCollection();

            //углы скругления
            double angTop = 60.0;
            double angDown = 15.0;
            using (Autodesk.AutoCAD.BoundaryRepresentation.Brep brep = new Autodesk.AutoCAD.BoundaryRepresentation.Brep(path))
            {
                foreach (Autodesk.AutoCAD.BoundaryRepresentation.Edge edge in brep.Edges)
                {
                    if (edge.Vertex1.Point.Z == -lenBox / 2)
                    {
                        subentIds.Add(edge.SubentityPath.SubentId);
                        radii.Add(angTop);

                        // Setback fillets. Defines a setback distance
                        // from a vertex at which the fillets start to blend
                        startSetback.Add(0.0);
                        endSetback.Add(angDown);
                    }
                    if (edge.Vertex1.Point.Z == lenBox / 2)
                    {
                        subentIds.Add(edge.SubentityPath.SubentId);
                        radii.Add(angDown);

                        startSetback.Add(0.0);
                        endSetback.Add(angDown);
                    }
                }
            }

            box.FilletEdges(subentIds.ToArray(), radii, startSetback, endSetback);

            // Position the center of the 3D solid at (5,5,0) 
            box.TransformBy(Matrix3d.Displacement(new Point3d(0, 0, 0) - Point3d.Origin));

            //Rotate
            double angle90 =Math.PI/2;// угол поворта = 90 градусов 
            Vector3d vRot = new Point3d(0, 0, 0).GetVectorTo(new Point3d(1, 0, 0));
            box.TransformBy(Matrix3d.Rotation(angle90, vRot, new Point3d(0, 0, 0)));

            double radiusBox = diameretBox / 2;
            double coordinate = (radiusBox * ((Math.Sqrt(2) - 1) / 2) + radiusBox) / Math.Sqrt(2);

            //поворта = 45 градусов
            double angle45 = Math.PI/4;

            //отрисовка лап
            double lenPaw = 0.9 * lenBox;
            BuildPawsBox(database, trans, radiusBox / 2, lenBox, radiusBox, -radiusBox, 0);
            BuildPawsBox(database, trans, radiusBox / 2, lenPaw, coordinate, -coordinate, angle45);
            BuildPawsBox(database, trans, radiusBox / 2, lenBox, -radiusBox, -radiusBox, 0);
            BuildPawsBox(database, trans, radiusBox / 2, lenPaw, -coordinate, -coordinate, -angle45);

            //Элементы радиатора
            int n = parameters.CountGrille;
            double coordX = 0;
            double coordZ = 0;
            double angleRadiatorElements = 40;
            double angleRadiatorStep = 5;
            if(n>1)
            {
                angleRadiatorStep = 80 / (n - 1);
            }

            for (int i = 0; i < n; i++)
            {
                if (angleRadiatorElements <= 40 && angleRadiatorElements >= -40)
                {
                    coordX = radiusBox * Math.Cos(angleRadiatorElements * Math.PI / 180);
                    coordZ = radiusBox * Math.Sin(angleRadiatorElements * Math.PI / 180);

                    BuildRadiator(database, trans, coordX, coordZ);
                    BuildRadiator(database, trans, -coordX, coordZ);

                    angleRadiatorElements -= angleRadiatorStep;
                }
            }
        }

        /// <summary>
        /// Функция построения части лапы мотора
        /// </summary>
        /// <param name="database">База данных</param>
        /// <param name="trans">Транзакция</param>
        /// <param name="width">Ширина части лапы</param>
        /// <param name="len">Длина части лапы</param>
        /// <param name="coordinateX">Позиция центра по координате Х </param>
        /// <param name="coordinateZ">Позиция центра по координате Z</param>
        /// <param name="angle">Угол вращения</param>
        private void BuildPawsBox(Database database, Transaction trans, double width, double len, double coordinateX, double coordinateZ, double angle)
        {
            double r = _diameretBox / 2;
            double koord = (r * ((Math.Sqrt(2) - 1) / 2) + r) / Math.Sqrt(2);

            // Open the Block table record for read
            BlockTable acBlkTbl;
            acBlkTbl = trans.GetObject(database.BlockTableId, OpenMode.ForRead) as BlockTable;

            // Open the Block table record Model space for write
            BlockTableRecord acBlkTblRec;
            acBlkTblRec = trans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

            // Create a 3D solid box
            Solid3d paw = new Solid3d();
            paw.SetDatabaseDefaults();
            paw.CreateBox(width, len, 20);
            paw.ColorIndex = 7;

            // Position the center of the 3D solid at (5,5,0) 
            paw.TransformBy(Matrix3d.Displacement(new Point3d(coordinateX, 0, coordinateZ) - Point3d.Origin));

            //Rotate
            Vector3d vRotPaw = new Point3d(0, 0, 0).GetVectorTo(new Point3d(0, 1, 0));
            paw.TransformBy(Matrix3d.Rotation(angle, vRotPaw, new Point3d(coordinateX, 0, coordinateZ)));

            // Add the new object to the block table record and the transaction
            acBlkTblRec.AppendEntity(paw);
            trans.AddNewlyCreatedDBObject(paw, true);            
        }

        /// <summary>
        /// Функция построения элементов радиаторной решетки
        /// </summary>
        /// <param name="database">База данных</param>
        /// <param name="trans">Транзакция</param>
        /// <param name="coordinateX">Позиция центра по координате Х</param>
        /// <param name="coordinateZ">Позиция центра по координате Z</param>
        private void BuildRadiator(Database database, Transaction trans, double coordinateX, double coordinateZ)
        {
            // Open the Block table record for read
            BlockTable acBlkTbl = trans.GetObject(database.BlockTableId, OpenMode.ForRead) as BlockTable;

            // Open the Block table record Model space for write
            BlockTableRecord acBlkTblRec = trans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

            // Create a 3D solid box
            double sizeY = _lenBox * 0.7;
            double sizeX = _diameretBox / 8;

            Solid3d paw = new Solid3d();
            paw.SetDatabaseDefaults();
            paw.CreateBox(sizeX, sizeY, 5);
            paw.ColorIndex = 3;

            // Position the center of the 3D solid at (5,5,0) 
            double coordY = -0.1 * _lenBox;
            paw.TransformBy(Matrix3d.Displacement(new Point3d(coordinateX, coordY, coordinateZ) - Point3d.Origin));

            
            // Add the new object to the block table record and the transaction
            acBlkTblRec.AppendEntity(paw);
            trans.AddNewlyCreatedDBObject(paw, true);
        }
    }
}
