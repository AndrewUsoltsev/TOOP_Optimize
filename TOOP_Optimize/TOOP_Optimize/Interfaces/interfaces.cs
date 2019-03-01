using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOP_Optimize.Interfaces
{
    interface IFunctional
    {
        double Value(double[] parameters);
        (double min, double max)[] Range { get; }
    }
    interface IFunctionalWithDiff : IFunctional
    {
        double DfDp(int i, double[] parameters);
    }

    interface IOptimizer
    {
        IFunctional functional { set; }
        double[] Optimize(double[] initial,
            IProgress<(double[] current, double residual, int progresslen, int progressval)> progress);
        double Eps { set; }
        DateTime MaxTime { set; }
    }

}
