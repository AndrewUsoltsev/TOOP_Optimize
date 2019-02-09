using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOP_Optimize.Interfaces
{
    interface Functional
    {
        double Value(double[] parameters);
        (double min, double max)[] Range { get; }
    }
    interface FunctionalWithDiff : Functional
    {
        double DfDp(int i, double[] parameters);
    }

    interface Optimizer
    {
        Functional functional { set; }
        double[] Optimize(double[] initial,
            IProgress<(double[] current, double residual, int progresslen, int progressval)> progress);
        double Eps { set; }
        DateTime MaxTime { set; }
    }

}
