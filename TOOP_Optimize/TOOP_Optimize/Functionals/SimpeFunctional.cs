using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize.Functionals
{
    public class SimpeFunctional : IFunctionalWithDiff
    {
        public SimpeFunctional()
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
  
}
