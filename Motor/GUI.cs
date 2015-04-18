using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.Windows.Forms;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;


namespace Motor
{
    public partial class GUI : Form
    {
        /// <summary>
        /// Конструктор формы 
        /// </summary>
        public GUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки
        /// </summary>
        /// <param name="sender"> Обьект, который вызвал событие</param>
        /// <param name="e"> Обьект класса передающий дополнительную информацию обработчику</param>
        private void StartBuild_Click(object sender, EventArgs e)
        {
            if (LenBox.Text == ""
                || DiameretBox.Text == ""
                || LenRotor.Text == ""
                || DiameretRotor.Text == ""
                || LenPin.Text == ""
                || WidthFindings.Text == ""
                || LenFindings.Text == ""
                || HeightFindings.Text == ""
                || DiameretPorts.Text == ""
                || CountPorts.Text == "")
            {
                MessageBox.Show(this, "Не все поля заполнены!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                List<int> parameters = new List<int>() 
                {
                    Convert.ToInt32(LenBox.Text, 10),
                    Convert.ToInt32(DiameretBox.Text, 10),
                    Convert.ToInt32(LenRotor.Text, 10),
                    Convert.ToInt32(DiameretRotor.Text, 10),
                    Convert.ToInt32(LenPin.Text, 10),
                    Convert.ToInt32(WidthFindings.Text, 10),
                    Convert.ToInt32(LenFindings.Text, 10),
                    Convert.ToInt32(HeightFindings.Text, 10),
                    Convert.ToInt32(DiameretPorts.Text, 10),
                    Convert.ToInt32(CountPorts.Text, 10),
                    Convert.ToInt32(CountGrille.Text, 10)
                };
                try 
                {
                    MotorParameters parametersMotor = new MotorParameters(parameters);                    
                    Motor.BuildMotor(parametersMotor);
                    Form.ActiveForm.Close();                    
                }
                catch(Exception exception) 
                {
                    MessageBox.Show(this, exception.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }               
            }
        }



        private void StartTest_Click(object sender, EventArgs e)
        {
#if DEBUG            
            // Диагностика времени выполнения функции
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();

            // Создание и открытие его для записи
            StreamWriter file = new StreamWriter("D:\\TestMOTOR.txt");

            for (int i = 0; i < 100; i++)
            {
                // Сброс
                myStopwatch.Reset(); 
                // Запуск
                myStopwatch.Start(); 
                     
                List<int> parameters = new List<int>() {300,200,50,50,10,50,100,30,10,3,7};
                MotorParameters parametersMotor = new MotorParameters(parameters);                    
                Motor.BuildMotor(parametersMotor);
                                   
                // Остановить
                myStopwatch.Stop(); 

                TimeSpan ts = myStopwatch.Elapsed;
                string elapsedTime = String.Format("{0:f}", ts.Milliseconds);
                // Запись в файл результатов
                file.Write(elapsedTime + "\n"); 
            }
            file.Close();
        }
#endif
    }    
}
