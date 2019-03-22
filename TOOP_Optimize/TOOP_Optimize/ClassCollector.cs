using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize
{
    public static class ClassCollector
    {
        public static List<Type> OptimizersTypes { get; } = new List<Type>();
        public static List<Type> FunctionalsTypes { get; } = new List<Type>();
        static ClassCollector()
        {
            var functType = typeof(IFunctional);
            FunctionalsTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => functType.IsAssignableFrom(p) && p.IsClass)
                .ToList();

            var optimType = typeof(IOptimizer);
            OptimizersTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => optimType.IsAssignableFrom(p) && p.IsClass)
                .ToList();

        }


    }
}
