using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Motor;

namespace TestMotor
{
    [TestFixture]
    public class Tests
    {
        [TestCase(300, 200, 50, 50, 10, 50, 100, 30, 5, 2, 0, TestName = "Положительное тестирование минимально допустимых параментров построения мотора")]
        [TestCase(600, 400, 200, 100, 200, 200, 200, 100, 30, 6, 20, TestName = "Положительное тестирование максимально допустимых параментров построения мотора")]

        [TestCase(299, 200, 50, 50, 10, 50, 100, 30, 5, 2, 0, TestName = "Негативное тестирование выхода за границы минимально допустимого параментра длина корпуса мотора", ExpectedException = typeof(Exception))]
        [TestCase(300, 199, 50, 50, 10, 50, 100, 30, 5, 2, 0, TestName = "Негативное тестирование выхода за границы минимально допустимого параментра диаметр корпуса мотора", ExpectedException = typeof(Exception))]
        [TestCase(300, 200, 49, 50, 10, 50, 100, 30, 5, 2, 0, TestName = "Негативное тестирование выхода за границы минимально допустимого параментра длина вала", ExpectedException = typeof(Exception))]
        [TestCase(300, 200, 50, 49, 10, 50, 100, 30, 5, 2, 0, TestName = "Негативное тестирование выхода за границы минимально допустимого параментра диаметр вала", ExpectedException = typeof(Exception))]
        [TestCase(300, 200, 50, 50, 9,  50, 100, 30, 5, 2, 0, TestName = "Негативное тестирование выхода за границы минимально допустимого параментра длина фиксирующей понки", ExpectedException = typeof(Exception))]
        [TestCase(300, 200, 50, 50, 10, 49, 100, 30, 5, 2, 0, TestName = "Негативное тестирование выхода за границы минимально допустимого параментра ширина коробки выводов", ExpectedException = typeof(Exception))]
        [TestCase(300, 200, 50, 50, 10, 50, 99,  30, 5, 2, 0, TestName = "Негативное тестирование выхода за границы минимально допустимого параментра длина коробки выводов", ExpectedException = typeof(Exception))]
        [TestCase(300, 200, 50, 50, 10, 50, 100, 29, 5, 2, 0, TestName = "Негативное тестирование выхода за границы минимально допустимого параментра высота коробки выводов", ExpectedException = typeof(Exception))]
        [TestCase(300, 200, 50, 50, 10, 50, 100, 30, -1, 2, 0, TestName = "Негативное тестирование выхода за границы минимально допустимого параментра диаметр отверстия коробки выводов", ExpectedException = typeof(Exception))]
        [TestCase(300, 200, 50, 50, 10, 50, 100, 30, 5, -1, 0, TestName = "Негативное тестирование выхода за границы минимально допустимого параментра количество элементов вывода", ExpectedException = typeof(Exception))]
        [TestCase(300, 200, 50, 50, 10, 50, 100, 30, 5, 0, -1, TestName = "Негативное тестирование выхода за границы минимально допустимого параментра количество элементов радиатора", ExpectedException = typeof(Exception))]

        [TestCase(601, 400, 200, 100, 200, 160, 200, 100, 30, 6, 20, TestName = "Негативное тестирование выхода за границы максимально допустимого параментра длина корпуса мотора", ExpectedException = typeof(Exception))]
        [TestCase(600, 401, 200, 100, 200, 160, 200, 100, 30, 6, 20, TestName = "Негативное тестирование выхода за границы максимально допустимого параментра диаметр корпуса мотора", ExpectedException = typeof(Exception))]
        [TestCase(600, 400, 201, 100, 200, 160, 200, 100, 30, 6, 20, TestName = "Негативное тестирование выхода за границы максимально допустимого параментра длина вала", ExpectedException = typeof(Exception))]
        [TestCase(600, 400, 200, 101, 200, 160, 200, 100, 30, 6, 20, TestName = "Негативное тестирование выхода за границы максимально допустимого параментра диаметр вала", ExpectedException = typeof(Exception))]
        [TestCase(600, 400, 200, 100, 201, 160, 200, 100, 30, 6, 20, TestName = "Негативное тестирование выхода за границы максимально допустимого параментра длина фиксирующей понки", ExpectedException = typeof(Exception))]
        [TestCase(600, 400, 200, 100, 200, 201, 200, 100, 30, 6, 20, TestName = "Негативное тестирование выхода за границы максимально допустимого параментра ширина коробки выводов", ExpectedException = typeof(Exception))]
        [TestCase(600, 400, 200, 100, 200, 160, 201, 100, 30, 6, 20, TestName = "Негативное тестирование выхода за границы максимально допустимого параментра длина коробки выводов", ExpectedException = typeof(Exception))]
        [TestCase(600, 400, 200, 100, 200, 160, 200, 101, 30, 6, 20, TestName = "Негативное тестирование выхода за границы максимально допустимого параментра высота коробки выводов", ExpectedException = typeof(Exception))]
        [TestCase(600, 400, 200, 100, 200, 160, 200, 100, 31, 6, 20, TestName = "Негативное тестирование выхода за границы максимально допустимого параментра диаметр отверстия коробки выводов", ExpectedException = typeof(Exception))]
        [TestCase(600, 400, 200, 100, 200, 160, 200, 100, 30, 7, 20, TestName = "Негативное тестирование выхода за границы максимально допустимого параментра количество элементов вывода", ExpectedException = typeof(Exception))]
        [TestCase(600, 400, 200, 100, 200, 160, 200, 100, 30, 6, 21, TestName = "Негативное тестирование выхода за границы максимально допустимого параментра количество элементов радиатора", ExpectedException = typeof(Exception))]
        public void TestsValidParametrs(int lenBox, int diameretBox, int lenRotor, int diameretRotor, int lenPin, int widthFindings, int lenFindings, int heightFindings, int diameretPorts, int countPorts, int countGrille)
        {
            var motorParametrs = new List<int>() 
            {
                lenBox, 
                diameretBox, 
                lenRotor, 
                diameretRotor, 
                lenPin, 
                widthFindings, 
                lenFindings,
                heightFindings, 
                diameretPorts , 
                countPorts,
                countGrille 
            };
            MotorParameters parameters = new MotorParameters(motorParametrs);
        }
    }
}