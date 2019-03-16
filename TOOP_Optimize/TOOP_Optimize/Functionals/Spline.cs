﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize.Functionals
{
    class Spline : IFunctional
    {
        public (double min, double max)[] Range => throw new NotImplementedException();

        public double Value(double[] parameters)
        {
            return CalcFunctional(parameters);
        }

        private int sizeSpline;
        private double[] nodesSpline;
        private double[] valueSpline;

        public Spline(int size, double[] nodes, double[] value)
        {
            sizeSpline = size;
            nodesSpline = nodes;
            valueSpline = value;
        }

        private double ermit(int num, double x, double h)
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

        private double CalcFunctional(double[] q)
        {
            var numPoint = 0;

            var A = new double[sizeSpline, sizeSpline];
            var b = new double[sizeSpline];
            var w = new double[sizeSpline];

            for (int i = 0; i < sizeSpline; i++)
            {
                w[i] = 1.0;
            }

            //Сборка А и б
            for (int k = 1; k < sizeSpline - 1; k++)
            {
                double startInterval = nodesSpline[k], endInterval = nodesSpline[k + 1];
                double h = endInterval - startInterval;
                while (numPoint < sizeSpline && nodesSpline[numPoint] < endInterval)
                {
                    double x = (nodesSpline[numPoint] - startInterval) / h;
                    for (int i = 0; i < 4; i++)
                    {
                        double psi_i = ermit(i, x, h);
                        for (int j = 0; j < 4; j++)
                        {
                            A[k + i, k + j] += w[k + i] * psi_i * ermit(j, x, h);
                        }
                        b[k + i] += w[k + i] * psi_i * valueSpline[numPoint];
                    }
                    numPoint++;
                }
            }


            return 0;
        }

        private double[] MultVectorToMatrix(double[] vector, double[,] matrix)
        {

            return vector;
        }

        private double[] MultVectorToVector(double[] vectorFirst, double[] vectorSecond)
        {

            return vectorFirst;
        }
    }
}
