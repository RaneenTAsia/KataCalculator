using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator
{
    public static class Extensions
    {
        public static decimal DecimalPlaces(this decimal value, int places)
        {
            return Math.Round(value, places);
        }
    }
}
