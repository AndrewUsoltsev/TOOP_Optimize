using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize.Functionals
{
    class LSM : IFunctional
    {
        private double[] X;
        private double[] Y;

        public LSM(double min, double max, double[] x, double[] y)
        {
            X = x;
            Y = y;
            Range = new[] { (min, max) };
        }

        public (double min, double max)[] Range { get; }

        public double Value(double[] parameters)
        {
            return CalcLSM(parameters[0], parameters[1]);
        }

        private double CalcLSM(double a, double b)
        {
            var sum = 0.0;
            var size = X.Count();
            for (int i = 0; i < size; i++)
            {
                sum += (Y[i] - (a * X[i] + b)) * (Y[i] - (a * X[i] + b));
            }
            return sum;
        }
    }
}
