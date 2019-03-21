using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TOOP_Optimize.Interfaces;
using TOOP_Optimize.Functionals;
using TOOP_Optimize.Formats;
using TOOP_Optimize.Optimizers;
using Newtonsoft.Json.Linq;

namespace TOOP_Optimize.Fabrics
{
    public static class FunctionalsFabric
    {
        public static IFunctional GetFunctional(string type, string functionalsData)
        {
            var createType = ClassCollector.FunctionalsTypes.Find(x => x.Name == type);
            var FunctionalConstructorsParams = createType.GetConstructors().FirstOrDefault().GetParameters();
            
            var paramArray = new List<Type>();
            var parametersValue = new List<object>();
            if (FunctionalConstructorsParams.Length > 0)
            {
                var jObject = JObject.Parse(functionalsData);
                foreach (var param in FunctionalConstructorsParams)
                {
                    paramArray.Add(param.ParameterType);
                    parametersValue.Add(jObject[param.Name].ToObject(param.ParameterType));
                }
            }
            var typeConstructor = createType
                .GetConstructor(paramArray.ToArray());

            return (IFunctional)typeConstructor
                .Invoke(parametersValue.ToArray());
        }
     

    }
}
