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
        public void GradientDescent_SimpleFunctional_Test()
        {
            double eps = 10e-7;
            var gradientDescent = new GradientDescent(new SimpleFunctional(), DateTime.MinValue.AddMinutes(5), eps);
            var result = gradientDescent.Optimize(new double[] {10},
                new Progress<(double[] current, double residual, int progresslen, int progressval)>());
            Assert.AreEqual(10.0,result[0],eps);
        }

        [TestMethod]
        public void RandomSearch_SimpleFunctional_Test()
        {
            double eps = 10e-7;
            var randomSearch = new RandomSearch(new SimpleFunctional(), DateTime.MinValue.AddMinutes(5), eps);
            var result = randomSearch.Optimize(new double[] { 10 },
                new Progress<(double[] current, double residual, int progresslen, int progressval)>());
            Assert.AreEqual(10.0, result[0], eps);
        }

        [TestMethod]
        public void NelderMead_SimpleFunctional_Test()
        {
            double eps = 10e-7;
            double trueMin = 0.0;
            var nelderMead = new NelderMead(new SimpleFunctional(), DateTime.MinValue.AddMinutes(5), eps);
            var result = nelderMead.Optimize(new double[] { 10 },
                new Progress<(double[] current, double residual, int progresslen, int progressval)>());
            Assert.IsTrue(Math.Abs(result[0] - trueMin) <= eps);
        }
    }
}
