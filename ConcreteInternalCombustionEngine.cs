using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_ICE
{
    public class ConcreteInternalCombustionEngine : InternalCombustionEngine
    {
        public ConcreteInternalCombustionEngine(double inertia, double[] torque, double[] speed,
                                                double overheatTemperature, double heatingRate,
                                                double coolingRate, double C)
            : base(inertia, torque, speed, overheatTemperature, heatingRate, coolingRate, C)
        {
        }

        protected override double CalculateAcceleration()
        {
            int speedIndex = Array.IndexOf(Speed, CurrentSpeed);

            if (speedIndex == -1)
            {
                // Если текущая скорость не найдена в массиве, используем предыдущее значение
                int previousIndex = Array.FindLastIndex(Speed, s => s < CurrentSpeed);
                double previousTorque = Torque[previousIndex];
                return previousTorque / Inertia;
            }

            return Torque[speedIndex] / Inertia;
        }


        protected override double CalculateHeating()
        {
            int speedIndex = Array.IndexOf(Speed, CurrentSpeed);

            if (speedIndex == -1)
            {
                // Если текущая скорость не найдена в массиве, используем предыдущее значение
                int previousIndex = Array.FindLastIndex(Speed, s => s < CurrentSpeed);
                double previousSpeed = Speed[previousIndex];
                return Torque[previousIndex] * HeatingRate + previousSpeed * previousSpeed * HeatingRate;
            }

            return Torque[speedIndex] * HeatingRate + CurrentSpeed * CurrentSpeed * CoolingRate;
        }

        protected override double CalculateCooling()
        {
            return CoefC * (CurrentTemperature - EnvironmentTemperature);
        }

        public double EnvironmentTemperature = 0; // Температура окружающей среды
    }
}
