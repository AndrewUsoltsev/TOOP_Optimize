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
    public static class OptimizersFabric
    {

        public static IOptimizer GetOptimizer(string type, IFunctional functionalWithDiff, DateTime maxTime, double eps)
        {
            
            var createType = ClassCollector.OptimizersTypes.Find(x => x.Name == type);

            var typeConstructor = createType
                .GetConstructor(new[] { typeof(IFunctional), typeof(DateTime), typeof(double) });

            if (typeConstructor == null)
                throw new Exception("Невозможно создать оптимизатор с заданными параметрами!");

            return (IOptimizer)typeConstructor.Invoke(new object[] { functionalWithDiff, maxTime, eps });
        }

    }
}
