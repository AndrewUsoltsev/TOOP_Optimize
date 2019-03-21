using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize.Functionals
{
    class Spline : IFunctional
    {
        private int sizeSpline;
        private double Min;
        private double Max;
        private double[] nodesSpline;
        private double[] valueSpline;

        public Spline(int size, double min, double max, double[] nodes, double[] value)
        {
            Min = min;
            Max = max;
            sizeSpline = size;
            nodesSpline = nodes;
            valueSpline = value;
            Range = new[] { (min, max) };
        }

        public (double min, double max)[] Range { get; }

        public double Value(double[] parameters)
        {
            return CalcFunctional(parameters);
        }

        private double ErmitBasicFunction(int num, double x, double h)
        {
            switch (num)
            {
                case 0:
                    return 1 - 3 * x * x + 2 * x * x * x;
                case 1:
                    return h * (x - 2 * x * x + x * x * x);
                case 2:
                    return 3 * x * x - 2 * x * x * x;
                case 3:
                    return h * (-x * x + x * x * x);
            }
            return 0;
        }

        private double LinearBasicFunction(int num, double x, double x1, double h)
        {
            switch (num)
            {
                case 0:
                    return (x1 - x) / h;
                case 1:
                    return (x - x1) / h;
            }
            return 0;
        }

        private double CalcFunctional(double[] q)
        {
            //var P = 0.0;
            var functional = 0.0;

            var w = new double[sizeSpline];
            var n = q.Count();

            for (int i = 0; i < sizeSpline; i++)
            {
                w[i] = 1.0;
            }

            var step_inter = (Max - Min) / n;
            var x1 = Min;
            var x2 = x1 + step_inter;
            for (int i_inter = 0; i_inter < n - 1; i_inter++)
            {
                for (int k = 0; k < sizeSpline; k++)
                {
                    var x = nodesSpline[k];
                    if (x1 <= x && x2 > x || i_inter == n - 2 && x2 == x)
                    {
                        var psi1 = LinearBasicFunction(0, x, x2, x2 - x1);
                        var psi2 = LinearBasicFunction(1, x, x1, x2 - x1);
                        var P = psi1 * q[i_inter] + psi2 * q[i_inter + 1];
                        functional += w[k] * (P - valueSpline[k]) * (P - valueSpline[k]);
                    }
                }
                x1 += step_inter;
                if (i_inter != n - 2)
                    x2 += step_inter;
                else
                    x2 = Max;
            }
            return functional;
        }
    }
}
