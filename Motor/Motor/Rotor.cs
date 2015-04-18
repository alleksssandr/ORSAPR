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
    /// Класс отвечающий за вал
    /// </summary>
    class Rotor : IPart
    {
        
        #region

        /// <summary>
        /// диаметр вала
        /// </summary>
        private int _diameretRotor; 

        /// <summary>
        /// длина вала
        /// </summary>
        private int _lenRotor;
  
        /// <summary>
        /// длина фикс. понки
        /// </summary>
        private int _lenPin;  

        #endregion

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parameters">Класс с параметрами построения мотора</param>
        public Rotor(MotorParameters parameters)
        {
            _diameretRotor = parameters.DiameretRotor;
            _lenRotor = parameters.LenRotor;
            _lenPin = parameters.LenPin;
        }

        /// <summary>
        /// Функция построения вала
        /// </summary>
        /// <param name="database">База данных</param>
        /// <param name="Trans">Транзакция</param>
        /// <param name="parameters">Класс с параметрами построения мотора</param>
        public void Build(Database database, Transaction trans, MotorParameters parameters)
            {

                int diameretRotor = _diameretRotor;
                int lenRotor = _lenRotor;
                int lenPin = _lenPin;

                int lenBox = parameters.LenBox;

                // Open the Block table record for read
                BlockTable acBlkTbl = trans.GetObject(database.BlockTableId, OpenMode.ForRead) as BlockTable;

                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec = trans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                // Create a 3D solid cylinder
                Solid3d rotor = new Solid3d();
                rotor.SetDatabaseDefaults();
                rotor.CreateFrustum(lenRotor, diameretRotor / 2, diameretRotor / 2, diameretRotor / 2);
                rotor.ColorIndex = 4;

                // Position the center of the 3D solid at (5,5,0) 
                rotor.TransformBy(Matrix3d.Displacement(new Point3d(0, -lenRotor / 2 - lenBox / 2, 0) - Point3d.Origin));

                //Rotate
                double angle = Math.PI / 2;//угол поворота

                Vector3d vRotRotor = new Point3d(0, 0, 0).GetVectorTo(new Point3d(1, 0, 0));
                rotor.TransformBy(Matrix3d.Rotation(angle, vRotRotor, new Point3d(0, -lenRotor / 2 - lenBox / 2, 0)));

                // Add the new object to the block table record and the transaction
                acBlkTblRec.AppendEntity(rotor);
                trans.AddNewlyCreatedDBObject(rotor, true);

                // Create a 3D solid box
                Solid3d pin = new Solid3d();
                pin.SetDatabaseDefaults();
                pin.CreateBox(diameretRotor / 10, lenPin, diameretRotor / 10);
                pin.ColorIndex = 7;

                // Position the center of the 3D solid at (5,5,0) 
                pin.TransformBy(Matrix3d.Displacement(new Point3d(0, -lenBox / 2 - lenRotor + lenPin / 2, diameretRotor / 2) - Point3d.Origin));

                // Add the new object to the block table record and the transaction
                acBlkTblRec.AppendEntity(pin);
                trans.AddNewlyCreatedDBObject(pin, true);
            }
    }
}
