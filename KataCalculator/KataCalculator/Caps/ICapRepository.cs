namespace KataCalculator.Caps
{
    public interface ICapRepository
    {
        Cap? FindUPCCap(int UPC);
        List<Cap> GetAll();
    }
}