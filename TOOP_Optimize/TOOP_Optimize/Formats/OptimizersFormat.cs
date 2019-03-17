using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOP_Optimize.Formats
{
    public class OptimizersFormat
    {
        public DateTime MaxTime { get; set; } = new DateTime().AddMinutes(2);
        public double Eps { get; set; } = 1E-6;

    }
}
