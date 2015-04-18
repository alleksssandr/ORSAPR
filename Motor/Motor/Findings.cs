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
    /// Класс отвечающий за коробку выводов
    /// </summary>
    public class Findings : IPart
     {

        
        #region
        /// <summary>
        /// ширина коробки выводов
        /// </summary>
        private int _widthFindings;     

        /// <summary>
        /// длина коробки выводов
        /// </summary>
        private int _lenFindings;      
 
        /// <summary>
        /// высота коробки выводов
        /// </summary>
        private int _heightFindings; 

        /// <summary>
        /// количество портов коробки выводов
        /// </summary>
        private int _countPorts; 

        /// <summary>
        /// диаметр портов коробки выводов
        /// </summary>
        private int _diameretPorts;

        #endregion

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parameters">Класс с параметрами построения мотора</param>
        public Findings(MotorParameters parameters)
        {
            _widthFindings = parameters.WidthFindings;
            _lenFindings = parameters.LenFindings;
            _heightFindings = parameters.HeightFindings;
            _countPorts = parameters.CountPorts;
            _diameretPorts = parameters.DiameretPorts;
        }

        /// <summary>
        /// Функция построения коробки выводов
        /// </summary>
        /// <param name="database">База данный объектов </param>
        /// <param name="Trans">Транзакции</param>
        /// <param name="parameters">Класс с параметрами построения мотора</param>
        public void Build(Database database, Transaction acTrans, MotorParameters parameters)
        {           
                int widthFindings = _widthFindings;
                int lenFindings = _lenFindings;
                int heightFindings =_heightFindings;
           
                int countPorts = _countPorts;
                int diameretPorts = _diameretPorts;

                int lenBox = parameters.LenBox;
                int diameretBox = parameters.DiameretBox;

                //Коэффициенты трансформации
                double transformationFactorLen = 1.2;
                double transformationFactorHeight = 0.1;

                //Открываем таблицу блоков для чтения
                BlockTable acBlkTbl = acTrans.GetObject(database.BlockTableId, OpenMode.ForRead) as BlockTable;

                //Открываем таблицу блоков модели для записи
                BlockTableRecord acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                // Создаем 3D обьект - прямоугольник
                Solid3d findings = new Solid3d();
                findings.SetDatabaseDefaults();
                findings.CreateBox(widthFindings, lenFindings, heightFindings);
                findings.ColorIndex = 7;

                // Задаем позицию центра 3D обьекта
                findings.TransformBy(Matrix3d.Displacement(new Point3d(0, -lenBox / 2 + transformationFactorLen * lenFindings / 2, diameretBox / 2 + heightFindings / 2 - transformationFactorHeight * heightFindings) - Point3d.Origin));

                // Add the new object to the block table record and the transaction
                acBlkTblRec.AppendEntity(findings);
                acTrans.AddNewlyCreatedDBObject(findings, true);

                //Параметры 
                double cavityWidth = widthFindings * 0.8;
                double cavityLen = lenFindings * 0.9;
                double cavityHeight = heightFindings * 0.8;

                // Create a 3D solid box
                Solid3d cavity = new Solid3d();
                cavity.SetDatabaseDefaults();
                cavity.CreateBox(cavityWidth, cavityLen, cavityHeight);
                cavity.TransformBy(Matrix3d.Displacement(new Point3d(0, -lenBox / 2 + transformationFactorLen * lenFindings / 2, diameretBox / 2 + heightFindings / 2 - transformationFactorHeight * heightFindings) - Point3d.Origin));

                // Add the new object to the block table record and the transaction
                acBlkTblRec.AppendEntity(cavity);
                acTrans.AddNewlyCreatedDBObject(cavity, true);

                findings.BooleanOperation(BooleanOperationType.BoolSubtract, cavity);


                double coordZ = diameretBox / 2 + heightFindings / 2 - transformationFactorHeight * heightFindings;
                double coordX = widthFindings / 3;


                if (countPorts >= 1)
                {
                    double y1 = -lenBox / 2 + (transformationFactorLen * lenFindings / 2 + lenFindings / 3);
                    Ports(database, acTrans, parameters, 0, findings, coordX, y1, coordZ);
                }
                if (countPorts > 2)
                {
                    double y2 = -lenBox / 2 + (transformationFactorLen * lenFindings / 2);
                    Ports(database, acTrans, parameters, 2, findings, coordX, y2, coordZ);
                }
                if (countPorts > 4)
                {
                    double y3 = -lenBox / 2 + (transformationFactorLen * lenFindings / 2 - lenFindings / 3);
                    Ports(database, acTrans, parameters, 4, findings, -coordX, y3, coordZ);
                }
        }

        /// <summary>
        /// Функция отрисовки портов вывода
        /// </summary>
        /// <param name="database">База данныйх</param>
        /// <param name="Trans">Транцакция</param>
        /// <param name="parameters">Класс с параметрами построения мотора</param>
        /// <param name="positionPort">Позиция отверстия</param>
        /// <param name="Figure">Обьект класса</param>
        /// <param name="x">Позиция центра по координате Х</param>
        /// <param name="y">Позиция центра по координате Y</param>
        /// <param name="z">Позиция центра по координате Z</param>
        private void Ports(Database database, Transaction trans, MotorParameters parameters, int positionPort, Solid3d figure, double x, double y, double z)
        {
            // Open the Block table record for read
            BlockTable acBlkTbl;
            acBlkTbl = trans.GetObject(database.BlockTableId, OpenMode.ForRead) as BlockTable;

            // Open the Block table record Model space for write
            BlockTableRecord acBlkTblRec = trans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

            // Создаем 3D обьект - прямоугольник
            Solid3d port = new Solid3d();
            port.SetDatabaseDefaults();
            port.CreateFrustum(_widthFindings * (parameters.CountPorts - positionPort), _diameretPorts / 2, _diameretPorts / 2, _diameretPorts / 2);
            port.ColorIndex = 4;

            // Перемещение и и поворот 
            port.TransformBy(Matrix3d.Displacement(new Point3d(x, y, z) - Point3d.Origin));
            Vector3d vRotPort = new Point3d(0, 0, 0).GetVectorTo(new Point3d(0, 1, 0));
            port.TransformBy(Matrix3d.Rotation(Math.PI / 2, vRotPort, new Point3d(x, y, z)));
            acBlkTblRec.AppendEntity(port);
            trans.AddNewlyCreatedDBObject(port, true);
            figure.BooleanOperation(BooleanOperationType.BoolSubtract, port);
        }
    }
}
