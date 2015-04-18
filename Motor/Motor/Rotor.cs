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

        #region Данные класса Ротор

        /// <summary>
        /// Диаметр вала
        /// </summary>
        private int _diameretRotor; 

        /// <summary>
        /// Длина вала
        /// </summary>
        private int _lenRotor;
  
        /// <summary>
        /// Длина фикс. понки
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

                // Открываем таблицу блоков для чтения
                BlockTable blockTable = trans.GetObject(database.BlockTableId, OpenMode.ForRead) as BlockTable;

                // Открываем таблицу блоков модели для записи
                BlockTableRecord blockTableRecord = trans.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                // Создам новый цилиндр
                Solid3d rotor = new Solid3d();
                rotor.SetDatabaseDefaults();
                rotor.CreateFrustum(lenRotor, diameretRotor / 2, diameretRotor / 2, diameretRotor / 2);
                rotor.ColorIndex = 4;

                // Позиция центра отрисовки обьекта 
                rotor.TransformBy(Matrix3d.Displacement(new Point3d(0, -lenRotor / 2 - lenBox / 2, 0) - Point3d.Origin));

                double angleRotate = Math.PI / 2;
                Vector3d vRotRotor = new Point3d(0, 0, 0).GetVectorTo(new Point3d(1, 0, 0));
                rotor.TransformBy(Matrix3d.Rotation(angleRotate, vRotRotor, new Point3d(0, -lenRotor / 2 - lenBox / 2, 0)));

                // Добавляем новый обьект в таблицу блоков и отправляем на транзакцию
                blockTableRecord.AppendEntity(rotor);
                trans.AddNewlyCreatedDBObject(rotor, true);

                // Созать новую фигуру
                Solid3d pin = new Solid3d();
                pin.SetDatabaseDefaults();
                pin.CreateBox(diameretRotor / 10, lenPin, diameretRotor / 10);
                pin.ColorIndex = 7;

                // Позиция центра
                pin.TransformBy(Matrix3d.Displacement(new Point3d(0, -lenBox / 2 - lenRotor + lenPin / 2, diameretRotor / 2) - Point3d.Origin));

                // Добавляем новый обьект в таблицу блоков и отправляем на транзакцию
                blockTableRecord.AppendEntity(pin);
                trans.AddNewlyCreatedDBObject(pin, true);
            }
    }
}
