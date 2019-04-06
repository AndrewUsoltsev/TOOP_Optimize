using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize.Optimizers
{
    public class NelderMead : IOptimizer
    {
        public NelderMead(IFunctional functional, DateTime maxTime, double eps)
        {
            this.functional = functional;
            this.Eps = eps;
            this.MaxTime = maxTime;
        }

        private int N => functional.Range.Length;

        public double Eps { get; set; }
        public DateTime MaxTime { get; set; }
        public IFunctional functional { get; set; }


        const double alpha = 1;
        const double gamma = 2;
        const double rho = 0.5;
        const double sigma = 0.5;


        public double[] Optimize(double[] initial,
            IProgress<(double[] current, double residual, int progresslen, int progressval)> progress)
        {
            if (initial == null)
            {
                throw new ArgumentNullException(nameof(initial));
            }

            if (progress == null)
            {
                throw new ArgumentNullException(nameof(progress));
            }

            if (initial.Length != N)
            {
                throw new ArgumentException($"Неправильная размерность входного вектора: {initial.Length} != {N}");
            }

            var residual = 0.0;
            var residualLastIter = 0.0;
            var lastVal = 0;
            double[] functionValues = new double[initial.Length + 1];
            var simplex = InitializeStartSimplex(initial);
            var time = new Stopwatch();
            time.Start();
            while (true)
            {
                for (int i = 0; i < simplex.GetLength(0); i++)
                {
                    functionValues[i] = functional.Value(simplex[i]);
                }

                Array.Sort(functionValues, simplex);

                FindCentroid(simplex, N, out var centroid);

                residualLastIter = residual;
                residual = Math.Abs(functionValues[N] - functionValues[0]);
                if (Math.Abs(residual - residualLastIter) < Eps)
                {
                    break;
                }

                var val = (int)(100 - Math.Abs(residual - residualLastIter) * 100);

                if (val > lastVal)
                {
                    progress.Report((simplex[0], residual, 100, val));
                    lastVal = val;
                }
                else
                    progress.Report((simplex[0], residual, 100, lastVal));

                if (MaxTime.Ticks - time.ElapsedTicks < 0)
                    return simplex[0];

                double reflectionValue = Reflection(centroid, simplex, out var reflectionPoint);

                if (reflectionValue >= functionValues[0] && reflectionValue < functionValues[N - 1])
                {
                    simplex[N] = reflectionPoint;
                    continue;
                }

                if (reflectionValue < functionValues[0])
                {
                    double expansionValue = Expansion(centroid, simplex, reflectionPoint, out var expansionPoint);

                    if (expansionValue < reflectionValue)
                    {
                        simplex[N] = expansionPoint;
                    }
                    else
                    {
                        simplex[N] = reflectionPoint;
                    }

                    continue;
                }

                double contractionValue = Contraction(centroid, simplex, out var contractionPoint);

                if (contractionValue < functionValues[N])
                {
                    simplex[N] = contractionPoint;
                    continue;
                }

                double[] bestPoint = simplex[0];
                for (int i = 0; i <= N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        simplex[i][j] = bestPoint[j] + sigma * (simplex[i][j] - bestPoint[j]);
                    }
                }
            }

            return simplex[0];
        }

        private void FindCentroid(double[][]simplex, int N, out double[] centroid)
        {
            centroid = new double[N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    centroid[i] += simplex[j][i];
                }

                centroid[i] /= N;
            }
        }

        private double Reflection(double[] centroid, double[][] simplex, out double[] reflectionPoint)
        {
            reflectionPoint = new double[N];
            for (int i = 0; i < N; i++)
            {
                reflectionPoint[i] = centroid[i] + alpha * (centroid[i] - simplex[N][i]);
            }

            return functional.Value(reflectionPoint);
        }

        private double Expansion(double[] centroid, double[][] simplex, 
            double[] reflectionPoint, out double[] expansionPoint)
        {
            expansionPoint = new double[N];
            for (int i = 0; i < N; i++)
            {
                expansionPoint[i] = centroid[i] + gamma * (reflectionPoint[i] - centroid[i]);
            }

            return functional.Value(expansionPoint);
        }

        private double Contraction(double[] centroid, double[][] simplex, out double[] contractionPoint)
        {
            contractionPoint = new double[N];
            for (int i = 0; i < N; i++)
            {
                contractionPoint[i] = centroid[i] + rho * (simplex[N][i] - centroid[i]);
            }

            return functional.Value(contractionPoint);
        }

        private double[][] InitializeStartSimplex(double[] initial)
        {
            double[][] startSimplex = new double[initial.Length + 1][];
            startSimplex[0] = initial;
            var zero = 0.00025;
            var notZero = 0.05; 
            for (int i = 1; i < initial.Length + 1; i++)
            {
                startSimplex[i] = new double[initial.Length];
                for (int j = 0; j < initial.Length; j++)
                {
                    if (Math.Abs(initial[j]) < Eps)
                    {
                        startSimplex[i][j] += startSimplex[i - 1][j] + zero;
                    }
                    else
                    {
                        startSimplex[i][j] += startSimplex[i - 1][j] + notZero;
                    }
                }
            }

            return startSimplex;
        }
    }
}
