using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Utils
{
    public static class Utilities
    {
        public static decimal ExtractGst(decimal total)
        {
            return Math.Round((total / 100) * 15, 2);
        }
    }
}
