using KataCalculator.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCalculator.Caps
{
    public class CapRepository
    {
        #region GetAll Method
        public static List<Cap> GetAll()
        {
            return new List<Cap>
            {
              new Cap( 20M, RelativeType.Percent,39846),
              new Cap( 4.00M, RelativeType.Absolute,2637458)
            };
        }
        #endregion
    }
}
