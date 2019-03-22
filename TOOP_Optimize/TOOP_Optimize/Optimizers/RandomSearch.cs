using System;
using System.Diagnostics;
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

        private int m { get;} = 100;

        private (double max, double min)[] Range { get; }

        private double[] GenerateRandomVector(Random rnd)
        {
            var functionalRange = functional.Range;
            var rndPoint = new double[FuncArguments];
            for (var i = 0; i < FuncArguments; i++)
            {
                rndPoint[i] = rnd.NextDouble(Range[i].min, Range[i].max);
            }

            return rndPoint;
        }

        private double[] FindMinWithMRandomThrows(double min, double[] oldPoint)
        {
            bool isChange = false;
            var point = new double[FuncArguments];
            for (var i = 0; i < m; i++)
            {
                var rndPoint = GenerateRandomVector(rnd);
                var value = functional.Value(rndPoint);
                if (min > value)
                {
                    min = value;
                    point = (double[])rndPoint.Clone();
                    isChange = true;
                }
            }

            if (isChange)
            {
                return point;
            }

            return oldPoint;
        }

        public double[] Optimize(double[] initial, IProgress<(double[] current, double residual, int progresslen, int progressval)> progress)
        {
            rnd = new Random();
            var min = functional.Value(initial);
            var time = new Stopwatch();
            double[] point = new double[initial.Length];
            time.Start();
            while (true)
            {
                point = FindMinWithMRandomThrows(min, point);
                min = functional.Value(point);

                for (var i = 0; i < FuncArguments; i++)
                {
                    var minRange = point[i] - (Range[i].max - Range[i].min) / 2;
                    var maxRange = point[i] + (Range[i].max - Range[i].min) / 2;
                    if (maxRange < functional.Range[i].max)
                    {
                        maxRange = functional.Range[i].min;
                    }

                    if (minRange < functional.Range[i].min)
                    {
                        minRange = functional.Range[i].max;
                    }
                    Range[i] = (maxRange, minRange);

                    if (Math.Abs(Range[i].max - Range[i].min) < Eps)
                        return point;

                    if (MaxTime.Ticks - time.ElapsedTicks < 0)
                        return point;
                }
            }
        }

        public double Eps { get; set; }

        public DateTime MaxTime { get; set; }
    }
}