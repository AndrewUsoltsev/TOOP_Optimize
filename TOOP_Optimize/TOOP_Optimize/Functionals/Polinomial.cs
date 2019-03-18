using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize.Functionals
{
    //y=a0+a1*x+...
    class Polinomial : IFunctional
    {
        private double[] coeff;

        public Polinomial(double[] coeff)
        {
            this.coeff = coeff;
        }

        public (double min, double max)[] Range => throw new NotImplementedException();

        public double Value(double[] parameters)
        {
            return Polynomial(coeff, parameters[0]);
        }

        private double Polynomial(double[] coeff, double x)
        {
            var sum = 0.0;
            var xBuf = 1.0;
            var degree = coeff.Count();

            for (int i = 0; i < degree; i++)
            {
                sum += coeff[i] * xBuf;
                xBuf *= x;
            }

            return sum;
        }
    }
}
