using System;
using System.IO;
using TOOP_Optimize.Extension;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize.Optimizers
{
    public class RandomSearch : IOptimizer
    {
        public RandomSearch(IFunctional f, DateTime maxTime, double eps)
        {
            this.functional = f;
            Range = f.Range;
            MaxTime = maxTime;
            Eps = eps;
        }

        public IFunctional functional { get; set; }

        private Random rnd;

        private int FuncArguments => functional.Range.Length;

        private int m { get;} = 10;

        private (double max, double min)[] Range { get; }

        private double[] GenerateRandomVector(Random rnd)
        {
            var functionalRange = functional.Range;
            var rndPoint = new double[FuncArguments];
            for (var i = 0; i < FuncArguments; i++)
            {
                rndPoint[i] = rnd.NextDouble(functionalRange[i].min, functionalRange[i].max);
            }

            return rndPoint;
        }

        private double[] FindMinWithMRandomThrows(double min)
        {
            var point = new double[FuncArguments];
            for (var i = 0; i < m; i++)
            {
                var rndPoint = GenerateRandomVector(rnd);
                var value = functional.Value(rndPoint);
                if (min > value)
                {
                    min = value;
                    point = (double[])rndPoint.Clone();
                }
            }

            return point;
        }

        public double[] Optimize(double[] initial, IProgress<(double[] current, double residual, int progresslen, int progressval)> progress)
        {
            rnd = new Random();
            var min = functional.Value(initial);
            while (true)
            {
                var point = FindMinWithMRandomThrows(min);
                min = functional.Value(point);

                for (var i = 0; i < FuncArguments; i++)
                {
                    Range[i] = (point[i] - (Range[i].max - Range[i].min) / 2
                        , point[i] + (Range[i].max - Range[i].min) / 2);

                    if (Range[i].max - Range[i].min < Eps)
                    {
                        return point;
                    }
                }
            }
        }

        public double Eps { get; set; }

        public DateTime MaxTime { get; set; }
    }
}