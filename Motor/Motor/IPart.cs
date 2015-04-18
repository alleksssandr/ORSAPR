using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

namespace Motor
{
    /// <summary>
    /// Интерфейс 
    /// </summary>
    interface IPart
    {
        /// <summary>
        /// Функция построения
        /// </summary>
        /// <param name="CurDb">База данных</param>
        /// <param name="Trans">Транзакция </param>
        /// <param name="param">Обьект класса параметры</param>
        void Build(Database curDb, Transaction trans, MotorParameters param);
    }
}
