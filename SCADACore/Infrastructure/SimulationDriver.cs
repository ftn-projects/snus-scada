using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADACore.Infrastructure
{
    public class SimulationDriver :  IDriver
    {

        public double ReadValue(int address)
        {
            switch (address)
            {
                case 1
                    return Sine();
                case 2:
                    return Cosine();
                case 3:
                    return Ramp();
                default:
                    return -1000;
            }
        }

        private static double Sine()
        {
            return 100 * Math.Sin((double)DateTime.Now.Second / 60 * Math.PI);
        }

        private static double Cosine()
        {
            return 100 * Math.Cos((double)DateTime.Now.Second / 60 * Math.PI);
        }

        private static double Ramp()
        {
            return 100 * DateTime.Now.Second / 60;
        }
    }
}