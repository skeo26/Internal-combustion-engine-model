using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_ICE
{
    public abstract class InternalCombustionEngine
    {
        public double Inertia { get; set; }
        public double[] Torque { get; set; }
        public double[] Speed { get; set; }
        public double OverheatTemperature { get; set; }
        public double HeatingRate { get; set; }
        public double CoolingRate { get; set; }
        public double CoefC { get; set; }

        protected double CurrentTemperature;
        protected double CurrentSpeed;

        public InternalCombustionEngine(double inertia, double[] torque, double[] speed,
                                        double overheatTemperature, double heatingRate,
                                        double coolingRate, double C)
        {
            Inertia = inertia;
            Torque = torque;
            Speed = speed;
            OverheatTemperature = overheatTemperature;
            HeatingRate = heatingRate;
            CoolingRate = coolingRate;
            CoefC = C;
            CurrentTemperature = 0; // Начальная температура
            CurrentSpeed = 0; // Начальная скорость
        }

        public void Simulate(double simulationTime)
        {
            for (double time = 0; time < simulationTime; time++)
            {
                double acceleration = CalculateAcceleration();
                CurrentSpeed += acceleration;
                double heating = CalculateHeating();
                double cooling = CalculateCooling();
                CurrentTemperature += heating - cooling;

                // Вывод шага симуляции на консоль
                Console.WriteLine($"Time: {time + 1} sec, Speed: {CurrentSpeed}, Temperature: {CurrentTemperature}");

                if (CurrentTemperature >= OverheatTemperature)
                {
                    Console.WriteLine("Engine overheated!");
                    return;
                }
            }

            Console.WriteLine("Simulation completed without overheating.");
        }

        protected abstract double CalculateAcceleration();
        protected abstract double CalculateHeating();
        protected abstract double CalculateCooling();
    }
}
