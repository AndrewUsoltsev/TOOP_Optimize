using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOOP_Optimize.Functionals;
using TOOP_Optimize.Optimizers;

namespace Tests.Optimizers
{
    [TestClass]
    public class GradientGescentTests
    {
        GradientDescent gradientDescent =
            new GradientDescent(new SimpleFunctional(), new DateTime().AddMinutes(5), 10);

        [TestMethod]
        public void Optimize_NotNullTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => gradientDescent.Optimize(null,
                new Progress<(double[] current, double residual, int progresslen, int progressval)>()));
        }
    }
}
