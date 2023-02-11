using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Caps
{
    public class Cap
    {
        public decimal Value { get; set; }
        public RelativeType RelativeType { get; set; }
        public int UPC { get; set; }

        public Cap(decimal Value, RelativeType relativeType, int UPC)
        {
            this.Value = Value;
            RelativeType = relativeType;
            this.UPC = UPC;
        }
    }
}
