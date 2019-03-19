using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TOOP_Optimize.Interfaces;
using TOOP_Optimize.Fabrics;
using TOOP_Optimize.Optimizers;

namespace TOOP_Optimize.Fabrics
{
    public enum EOptimezerType
    {
        RandomSearch,
        GoldenRatio,
        GradientDescent,
        NedlerMead,
    }

    public class OptimizersFabric
    {
        public IOptimizer GetOptimizer(EOptimezerType type, IFunctional functionalWithDiff, DateTime maxTime, double eps)
        {
             
            switch(type)
            {
                case EOptimezerType.GoldenRatio:
                    return new GoldenRatio();
                case EOptimezerType.GradientDescent:
                    return new GradientDescent(functionalWithDiff, maxTime, eps);
                case EOptimezerType.RandomSearch:
                    return new RandomSearch(functionalWithDiff, maxTime, eps);
                default:
                    return new GoldenRatio();
            }
        }

        public IOptimizer GetOptimizer(string type, IFunctional functionalWithDiff, DateTime maxTime, double eps)
        {
            var t = typeof(IOptimizer);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => t.IsAssignableFrom(p))
                .ToList();

            switch (type)
            {
                case "GoldenRatio":
                    return new GoldenRatio();
                case "GradientDescent":
                    return new GradientDescent(functionalWithDiff, maxTime, eps);
                case "RandomSearch":
                    return new RandomSearch(functionalWithDiff, maxTime, eps);
                default:
                    return new GoldenRatio();
            }
        }

    }
}
