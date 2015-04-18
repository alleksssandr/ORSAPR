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
    /// Класс, инициализирующий плагин и выполняющий построение мотора
    /// </summary>
    class Motor : IExtensionApplication
    {
        /// <summary>
        /// Функция инициализации (выполняется при загрузке плагина)
        /// </summary>
        public void Initialize()
        {
            GUI form = new GUI();
            form.ShowDialog();
        }

        /// <summary>
        /// Функция, выполняемая при выгрузке плагина
        /// </summary>
        public void Terminate()
        {
        }

        /// <summary>
        /// Построение модели
        /// </summary>
        /// <param name="parameters">Класс с параметрами построения мотора</param>
        public static void BuildMotor(MotorParameters parameters)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            Database database = doc.Database;

            Transaction trans = database.TransactionManager.StartTransaction();

            // Коробка выводов
            IPart finding = new Findings(parameters);
            finding.Build(database, trans, parameters);

            // Корпус мотора
            IPart box = new Box(parameters);
            box.Build(database, trans, parameters);

            // Ротор
            IPart rotor = new Rotor(parameters);
            rotor.Build(database, trans, parameters);

            trans.Commit();
        }
    }
}