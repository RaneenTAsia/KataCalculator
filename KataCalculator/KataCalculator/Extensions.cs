namespace KataCalculator
{
    public static class Extensions
    {
        public static decimal DecimalPlaces(this decimal value, int places)
        {
            return Math.Round(value, places);
        }

        public static string AddCurrency(this decimal value, string Currency)
        {
            return value + " " + Currency;
        }
    }
}
