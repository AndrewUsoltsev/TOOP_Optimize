using System;

namespace TOOP_Optimize.Extension
{
    public static class RandomExtension
    {
        public static double NextDouble(this Random r, double min, double max)
        {
            return min + r.NextDouble() * (max - min);
        }
    }
}