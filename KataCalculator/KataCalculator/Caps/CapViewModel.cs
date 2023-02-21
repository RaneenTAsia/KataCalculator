namespace KataCalculator.Caps
{
    public class CapViewModel
    {
        public List<Cap> list { get; set; }

        public CapViewModel()
        {
            list = CapRepository.GetAll();
        }

        public Cap? FindUPCCap(int UPC)
        {
            Cap? cap = list.Where(cap => cap.UPC == UPC).Select(cap => cap).FirstOrDefault();
            return cap;
        }
    }
}
