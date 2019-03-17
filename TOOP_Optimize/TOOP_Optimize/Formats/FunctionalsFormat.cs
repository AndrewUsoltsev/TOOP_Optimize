using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOP_Optimize.Formats
{
    public class FunctionalsFormat
    {
        public FunctionalsFormat()
        {
            PolinomialFunctionalFormat = new PolinomialFunctional();
        }

        //public FunctionalsFormat(double[] coeff = null)
        //{
        //    if (coeff != null)
        //        PolinomialFunctionalFormat = new PolinomialFunctional(coeff);
        //}

        public PolinomialFunctional PolinomialFunctionalFormat { get; set; }

        public class PolinomialFunctional
        {
            public double[] Coeff { get; set; } = new double[] { 1, 1 };

            public PolinomialFunctional()
            {

            }

            public PolinomialFunctional(double[] coeff)
            {
                Coeff = coeff;
            }
        }

    }
}
