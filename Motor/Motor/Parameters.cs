using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motor
{
    /// <summary>
    /// Класс, содержащий параметры постороения мотора
    /// </summary>
    public class MotorParameters
    {

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parameters">Список параметров</param>
        public MotorParameters(List<int> parameters)
        {
            var errors = Validation(parameters);
            if (errors != "")
            {
                throw new Exception(errors);
            }

            LenBox         = parameters[0];
            DiameretBox    = parameters[1];
            LenRotor       = parameters[2];
            DiameretRotor  = parameters[3];
            LenPin         = parameters[4];
            WidthFindings  = parameters[5];
            LenFindings    = parameters[6];
            HeightFindings = parameters[7];
            DiameretPorts  = parameters[8];
            CountPorts     = parameters[9];
            CountGrille    = parameters[10];            
        }

        #region Properties

        /// <summary>
        /// Длина корпуса
        /// </summary>
        public int LenBox        { get; private set; }  

        /// <summary>
        /// Диаметр корпуса
        /// </summary>
        public int DiameretBox   { get; private set; } 

        /// <summary>
        /// Длина вала
        /// </summary>
        public int LenRotor      { get; private set; } 
 
        /// <summary>
        /// Диаметр вала
        /// </summary>
        public int DiameretRotor { get; private set; }

        /// <summary>
        /// Длина фиксирующей понки
        /// </summary>
        public int LenPin        { get; private set; }

        /// <summary>
        /// Ширина коробки выводов
        /// </summary>
        public int WidthFindings { get; private set; }

        /// <summary>
        /// Длина коробки выводов
        /// </summary>
        public int LenFindings   { get; private set; }

        /// <summary>
        /// Высота коробки выводов
        /// </summary>
        public int HeightFindings{ get; private set; }

        /// <summary>
        /// Диаметр отверстий выводов
        /// </summary>
        public int DiameretPorts { get; private set; }

        /// <summary>
        /// Количество отверстий выводов
        /// </summary>
        public int CountPorts    { get; private set; }

        /// <summary>
        /// Количество элементов радиатора
        /// </summary>
        public int CountGrille   { get; private set; }

        #endregion

       /// <summary>
       /// Функция проверки правильности параметров мотора
       /// </summary>
       /// <param name="parameters"> Лист параметров</param>
        private string Validation(List<int> parameters)
        {
            string errors = "";
            if (parameters[0] < 300 || parameters[0] > 600)
            {
                errors += ("Длина корпуса введена не корректно (введите значение от 300 мм, до 600 мм!");
            }
            if (parameters[1] < 200 || parameters[1] > 400)
            {
                errors += ("Диаметр корпуса введен не корректно (введите значение от 200 мм, до 400 мм!");
            }
            if (parameters[2] < 50 || parameters[2] > 200)
            {
                errors += ("Длина вала введена не корректно (введите значение от 50 мм, до 200 мм!");
            }
            if (parameters[3] < 50 || parameters[3] > (parameters[1] / 4))
            {
                errors += ("Диаметр вала введен не корректно (введите значение от 50 мм, до 1/4 диаметра корпуса!");
            }
            if (parameters[4] < 10 || parameters[4] > parameters[2])
            {
                errors += ("Длина фиксирующей понки введена не корректно (введите значение от 10 мм, до значения длины вала!");
            }
            if (parameters[5] < 50 || (parameters[5] > 160 && (parameters[5] > parameters[1] / 2)))
            {
                errors += ("Ширина коробки выводов введена не корректно (введите значение от 50 мм, до 160, но не более 1/2 ширины корпуса!");
            }
            if (parameters[6] < 100 || (parameters[6] > 200 && parameters[6] > parameters[0] / 3))
            {
                errors += ("Длина коробки выводов введена не корректно (введите значение от 100 мм, до 200 мм, но не более 1/3 длины корпуса)!");
            }
            if (parameters[7] < 30 || parameters[7] > 100)
            {
                errors += ("Высота коробки выводов введена не корректно (введите значение от 30 мм, до 100 мм!");
            }
            if (parameters[8] < 1 || (parameters[8] > parameters[7] / 3 || parameters[8] > 30))
            {
                errors += ("Диаметр отверстия коробки выводов введен не корректно (введите значение не более 1/3 высоты коробки выводов, но не более 30!");
            }
            if (parameters[9] < 1 || parameters[9] > 6)
            {
                errors += ("Количество подводимых кабелей введено не корректно (введите значение от 1 до 6!");
            }
            if (parameters[10] < 0 || parameters[10] > 20)
            {
                errors += ("Количество элементов радиаторной решетки введено не корректно (введите значение от 0 до 20!");
            }
            return errors;
        }
    }
}
