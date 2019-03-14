using System;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize.Optimizers
{
    public class GoldenRatio : IOptimizer
    {
        private readonly double fi = (1 + Math.Sqrt(5)) / 2; 

        public IFunctional functional { get; set; }

        public double[] Optimize(double[] initial, IProgress<(double[] current, double residual, int progresslen, int progressval)> progress)
        {
            if (initial.Length != 2)
            {
                throw new ArgumentException("Wrong arguments", nameof(initial));
            }

            var a = initial[0];
            var b = initial[1];

            if (a > b)
            {
                a = initial[1];
                b = initial[0];
            }

            var x1 = a + (3 - Math.Sqrt(5)) / 2 * (b - a);
            var x2 = a + (3 - Math.Sqrt(5)) / 2 * (b - a);

            while (true)
            {
                if (functional.Value(new double[] {x1}) < functional.Value(new double[] {x2}))
                {
                    
                }
            }

            throw new NotImplementedException();
        }

        public double Eps { get; set; }
        public DateTime MaxTime { get; set; }
        IFunctionalWithDiff IOptimizer.functional { set => throw new NotImplementedException(); }
    }
}