using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TOOP_Optimize.Interfaces;


namespace TOOP_Optimize.Optimizers
{
    class F: FunctionalWithDiff
    {
        public F()
        {
            Range = new []{(-10.0, 10.0)};
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

    public class GradientDescent : Optimizer
    {
        public FunctionalWithDiff functional { get; set; }

        private int FuncArguments => functional.Range.Length;

        private bool CheckRange(double[] point)
        {
            return functional.Range.Where((range, i) => point[i] < range.min || point[i] > range.max).Any();
        }
        // Нужно находить из условия минимизации, а не задавать от балды 
        private double alpha { get; set; } = 0.01;

        public GradientDescent(FunctionalWithDiff func, DateTime maxTime, double eps)
        {
            functional = func;
            MaxTime = maxTime;
            Eps = eps;
        }

        public double[] Optimize(double[] initial, IProgress<(double[] current, double residual, int progresslen, int progressval)> progress)
        {
            if (CheckRange(initial))
            {
                throw new ArgumentException(nameof(initial), "Initial array has wrong demension.");
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
            Stopwatch time = new Stopwatch();
            var newPoint = new double[initial.Length];
            double currentValue = 0;
            double newValue = 0;
            time.Start();
            while (true)
            {
                currentValue = functional.Value(currentPoint);

                for (var i = 0; i < currentPoint.Length; i++)
                {
                    var value = currentPoint[i];
                    newPoint[i] = value - alpha * functional.DfDp(i, currentPoint);
                    //Возможно, стоит делать эту проверку на область в цикле
                }

                if (CheckRange(newPoint))
                {
                    alpha /= 2;
                    newPoint = (double[])currentPoint.Clone();
                }

                newValue = functional.Value(newPoint);

                if (Math.Abs(currentValue - newValue) <= Eps)
                    return newPoint;

                if (MaxTime.Ticks - time.ElapsedTicks < 0)
                    return newPoint;

                currentPoint = (double[])newPoint.Clone();

                // progress.Report(currentPoint, Eps, iterNum);
            }
        }

        public double Eps { get; set; }
        public DateTime MaxTime { get; set; }
    }
}
