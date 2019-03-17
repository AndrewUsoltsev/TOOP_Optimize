using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOOP_Optimize.Interfaces;
using TOOP_Optimize.Functionals;
using TOOP_Optimize.Formats;

namespace TOOP_Optimize.Fabrics
{
    public class FunctionalsFabric
    {
        public IFunctional GetPolinomialFunctional(double[] coeff)
        {
            return new Polinomial(coeff);
        }

       
        public IFunctional GetFunctional(string type, FunctionalsFormat functionalsFormat)
        {
            switch (type)
            {
                case "Polinomial":
                    return new Polinomial(functionalsFormat.PolinomialFunctionalFormat.Coeff);
                default:
                    return null;
            }
        }

    }
}
