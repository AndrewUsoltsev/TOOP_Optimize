using System;
using System.Collections;
using System.Collections.Generic;
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

        public IFunctional functional { get; set; }

        const double alpha = 1;
        const double gamma = 2;
        const double rho = 0.5;
        const double sigma = 0.5;

        public double[] Optimize(double[] initial,
            IProgress<(double[] current, double residual, int progresslen, int progressval)> progress)
        {
            var residual = 0.0;
            var residualLastIter = 0.0;
            var lastVal = 0;
            double[] functionValues = new double[initial.Length + 1];
            var simplex = InitializeStartSimplex(initial);
            var N = initial.Length;
            while (true)
            {
                for (int i = 0; i < simplex.GetLength(0); i++)
                {
                    functionValues[i] = functional.Value(simplex[i]);
                }

                Array.Sort(functionValues, simplex);

                // Find centroid
                double[] centroid = new double[initial.Length];
                for (int i = 0; i < initial.Length; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        centroid[i] += simplex[j][i];
                    }

                    centroid[i] /= N;
                }

                if (Math.Abs(residual) > Eps)
                {
                    residualLastIter = residual;
                }
                residual = Math.Abs(functionValues[N] - functionValues[0]);
                if (residual < Eps)
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


                double[] reflectionPoint = new double[initial.Length];
                for (int i = 0; i < initial.Length; i++)
                {
                    reflectionPoint[i] = centroid[i] + alpha * (centroid[i] - simplex[N][i]);
                }

                double reflectionValue = functional.Value(reflectionPoint);

                if (reflectionValue >= functionValues[0] && reflectionValue < functionValues[N - 1])
                {
                    simplex[N] = reflectionPoint;
                    continue;
                }

                // Expansion
                if (reflectionValue < functionValues[0])
                {
                    double[] expansionPoint = new double[N];
                    for (int i = 0; i < N; i++)
                    {
                        expansionPoint[i] = centroid[i] + gamma * (reflectionPoint[i] - centroid[i]);
                    }

                    double expansionValue = functional.Value(expansionPoint);

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

                // Contraction
                double[] contractionPoint = new double[N];
                for (int i = 0; i < N; i++)
                {
                    contractionPoint[i] = centroid[i] + rho * (simplex[N][i] - centroid[i]);
                }

                double contractionValue = functional.Value(contractionPoint);

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

        public double Eps { get; set; }
        public DateTime MaxTime { get; set; }

        private double[][] InitializeStartSimplex(double[] initial)
        {
            double[][] startSimplex = new double[initial.Length + 1][];
            startSimplex[0] = initial;
            for (int i = 1; i < initial.Length + 1; i++)
            {
                startSimplex[i] = new double[initial.Length];
                for (int j = 0; j < initial.Length; j++)
                {
                    if (Math.Abs(initial[j]) < 10e-8)
                    {
                        startSimplex[i][j] += startSimplex[i - 1][j] + 0.00025;
                    }
                    else
                    {
                        startSimplex[i][j] += startSimplex[i - 1][j] + 0.05;
                    }
                }
            }

        return startSimplex;
        }

    }
}