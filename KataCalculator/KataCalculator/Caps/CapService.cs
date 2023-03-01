namespace KataCalculator.Caps
{
    public class CapService
    {
        public readonly ICapRepository _capRepository;

        public CapService(ICapRepository capRepository)
        {
            _capRepository = capRepository;
        }

        public List<Cap> GetAll()
        {
            return _capRepository.GetAll();
        }

        public Cap? FindUPCCap(int UPC)
        {
            return _capRepository.FindUPCCap(UPC);
        }
    }
}
