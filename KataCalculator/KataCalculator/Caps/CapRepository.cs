using System.Collections.Generic;

namespace KataCalculator.Caps
{
    public class CapRepository : ICapRepository
    {
        private readonly List<Cap> _capList =
            new List<Cap>
            {
              new Cap( 20M, RelativeType.Percent,39846),
              new Cap( 4.00M, RelativeType.Absolute,2637458)
            };

        #region GetAll Method
        public List<Cap> GetAll()
        {
            return _capList;
        }
        #endregion

        public Cap? FindUPCCap(int UPC)
        {
            return _capList.Where(cap => cap.UPC == UPC).Select(cap => cap).FirstOrDefault();
        }
    }
}
