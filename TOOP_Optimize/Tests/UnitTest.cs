using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOOP_Optimize.Functionals;
using TOOP_Optimize.Optimizers;

namespace Tests
{
    [TestClass]
    public class OptimaizersTests
    {
        [TestMethod]
        public void GradientDescent_Sip()
        {
            double eps = 10e-7;
            var gradientDescent = new GradientDescent(new SimpleFunctional(), DateTime.MinValue.AddMinutes(5), eps);
            var result = gradientDescent.Optimize(new double[] {10},
                new Progress<(double[] current, double residual, int progresslen, int progressval)>());
            Assert.AreEqual(10.0,result[0],eps);
        }
    }
}
