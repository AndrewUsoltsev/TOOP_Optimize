using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TOOP_Optimize.Interfaces;


namespace TOOP_Optimize.Optimizers
{
    public class F : IFunctionalWithDiff
    {
        public F()
        {
            Range = new[] { (10.0, 20.0) };
        }

        public double Value(double[] parameters)
        {
            return parameters[0] * parameters[0] + 1;
        }

        public (double min, double max)[] Range { get; }

        public double DfDp(int i, double[] parameters)
        {
            if (i == 0)
            {
                return 2 * parameters[0];
            }

            throw new ArgumentOutOfRangeException(nameof(i));
        }
    }

    public class GradientDescent : IOptimizer
    {
        private int FuncArguments => functional.Range.Length;

        private bool AtRange(double[] point)
        {
            return functional.Range.Where((range, i) => point[i] < range.min || point[i] > range.max).Any();
        }
        private double alpha { get; set; } = 0.01;

        public double Eps { get; set; }

        public DateTime MaxTime { get; set; }

        public IFunctional functional { set; get; }

        public GradientDescent(IFunctional func, DateTime maxTime, double eps)
        {
            functional = (IFunctionalWithDiff)func;
            MaxTime = maxTime;
            Eps = eps;
        }

        public double[] Optimize(double[] initial, IProgress<(double[] current, double residual, int progresslen, int progressval)> progress)
        {
            if (AtRange(initial))
            {
                throw new ArgumentException(@"Initial array has wrong demension.", nameof(initial));
            }

            if (progress == null)
            {
                throw new ArgumentNullException(nameof(progress));
            }

            if (initial == null)
            {
                throw new ArgumentNullException(nameof(initial));
            }

            var currentPoint = initial;
            double residualLastIter = 0.0;
            var time = new Stopwatch();
            var newPoint = new double[initial.Length];
            double residual = 0.0;
            time.Start();
            while (true)
            {
                var currentValue = functional.Value(currentPoint);

                for (var i = 0; i < currentPoint.Length; i++)
                {
                    var value = currentPoint[i];
                    newPoint[i] = value - alpha * ((IFunctionalWithDiff)functional).DfDp(i, currentPoint);
                }

                if (AtRange(newPoint))
                {
                    alpha /= 2;
                    newPoint = (double[])currentPoint.Clone();
                }

                var newValue = functional.Value(newPoint);

                if (residual > Eps)
                {
                    residualLastIter = residual;
                }

                residual = Math.Abs(currentValue - newValue);
                
                if (residual <= Eps)
                    return newPoint;

                if (MaxTime.Ticks - time.ElapsedTicks < 0)
                    return newPoint;

                
                currentPoint = (double[])newPoint.Clone();
                int val;
                if (Math.Abs(residualLastIter) < Eps)
                {
                    val = 0;
                }
                else
                {
                    val = (int)(100 - Math.Abs(residual - residualLastIter) * 100);
                }

                progress.Report((currentPoint, residual, 100, val));
            }
        }
    }
}
