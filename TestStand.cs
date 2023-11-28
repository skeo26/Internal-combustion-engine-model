using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_ICE
{
    public class TestStand
    {
        public double RunTest(InternalCombustionEngine engine, double simulationTime)
        {
            engine.Simulate(simulationTime);
            return simulationTime;
        }
    }
}
