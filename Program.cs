using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_ICE
{
    class Program
    {
        static void Main()
        {
            double inertia = 10;
            double[] torque = { 20, 75, 100, 105, 75, 0 };
            double[] speed = { 0, 75, 150, 200, 250, 300 };
            double overheatTemperature = 110;
            double heatingRate = 0.01;
            double coolingRate = 0.0001;
            double C = 0.1;

            // Создание двигателя внутреннеого сгорания
            InternalCombustionEngine engine = new ConcreteInternalCombustionEngine(inertia, torque, speed,
                                                                                   overheatTemperature, heatingRate,
                                                                                   coolingRate, C);
            TestStand testStand = new TestStand();

            // Получение температуры окружающей среды от пользователя
            Console.Write("Enter the ambient temperature: ");
            double ambientTemperature = Convert.ToDouble(Console.ReadLine());

            // Установка температуры окружающей среды в двигателе
            ((ConcreteInternalCombustionEngine)engine).EnvironmentTemperature = ambientTemperature;

            // Запуск теста
            double simulationTime = testStand.RunTest(engine, 500);

            Console.WriteLine($"Test completed in {simulationTime} seconds.");
            Console.ReadLine();
        }
    }

}
