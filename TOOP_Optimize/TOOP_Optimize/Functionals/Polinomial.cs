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
        private double[] Сoeff;

        public Polinomial(double min, double max, double[] coeff)
        {
            Сoeff = coeff;
            Range = new[] { (min, max) };
        }

        public (double min, double max)[] Range { get; }

        public double Value(double[] parameters)
        {
            return CalcPolynomial(parameters[0]);
        }

        private double CalcPolynomial(double x)
        {
            var sum = 0.0;
            var xBuf = 1.0;
            var degree = Сoeff.Count();

            for (int i = 0; i < degree; i++)
            {
                sum += Сoeff[i] * xBuf;
                xBuf *= x;
            }

            return sum;
        }
    }
}
