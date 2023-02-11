using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator
{
    public static class Extensions
    {
        public static string Currency { get; set; } = "USD";
        public static decimal DecimalPlaces(this decimal value, int places)
        {
            return Math.Round(value, places);
        }
        public static string AddCurrency(this decimal value)
        {
            return value+" " + Currency;
        }
    }
}
