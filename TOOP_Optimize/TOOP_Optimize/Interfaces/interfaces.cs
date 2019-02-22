using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOP_Optimize.Interfaces
{
    public interface IFunctional
    {
        double Value(double[] parameters);
        (double min, double max)[] Range { get; }
    }
    public interface IFunctionalWithDiff : IFunctional
    {
        double DfDp(int i, double[] parameters);
    }

    public interface IOptimizer
    {
        IFunctional functional { set; }
        double[] Optimize(double[] initial,
            IProgress<(double[] current, double residual, int progresslen, int progressval)> progress);
        double Eps { set; }
        DateTime MaxTime { set; }
    }

}
