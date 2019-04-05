using System;

namespace TOOP_Optimize.Exeptions
{
    public class FunctionalWithoutDiffException : Exception
    {
        public FunctionalWithoutDiffException()
        {

        }

        public FunctionalWithoutDiffException(string name)
            : base(($"Functionals without explicit differential aren`t supported {name}"))
        {

        }
    }
}