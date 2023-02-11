// See https://aka.ms/new-console-template for more information
using KataCalculator;
using KataCalculator.Caps;
using KataCalculator.Discounts;
using KataCalculator.Products;

PriceCalculator PriceCalculator = new PriceCalculator();

ChangeDefaultTaxAndDiscount(PriceCalculator);

CombinationType CombinationType = ReadCombinationType();

ChangeCurrency();

PrintProducts(PriceCalculator, CombinationType);

static void PrintProducts(PriceCalculator priceCalculator, CombinationType combinationType)
{
    ProductViewModel ProductViewModel = new ProductViewModel();

    foreach (var item in ProductViewModel.Products)
    {
        priceCalculator.printCalculations(item, combinationType);
        Console.WriteLine();
    }
}

static decimal? CheckDecimalInput()
{
    string input = Console.ReadLine();
    return string.IsNullOrEmpty(input) ? null : Decimal.Parse(input);
}

static void ChangeDefaultTaxAndDiscount(PriceCalculator priceCalculator)
{
    Console.WriteLine("Specify Tax:");
    decimal? tax = CheckDecimalInput();

    Console.WriteLine();

    Console.WriteLine("Specify general discount");
    decimal? discount = CheckDecimalInput();

    if (tax != null)
        priceCalculator.TaxPercent = (decimal)tax;

    if (discount != null)
        priceCalculator.DiscountPercent = (decimal)discount;

    Console.WriteLine();
}

static CombinationType ReadCombinationType()
{
    Console.WriteLine("Enter Additive or Multiplicative for Discount Combining Method:");
    string input = Console.ReadLine().ToLower();
    Console.WriteLine();

    if (string.IsNullOrEmpty(input) || input.Equals("additive"))
    {
        return CombinationType.Additive;
    }
    else
    {
        return CombinationType.Multiplicative;
    }
}

static string ReadCurrency()
{
    Console.WriteLine("Specify Currency");
    string? input = Console.ReadLine();

    if (input != null && input.Length > 3)
    {
        input = input.Substring(0,3);
    }

    return input.ToUpper();
}

static void ChangeCurrency()
{
    string? change = ReadCurrency();
    if (change != null)
        Extensions.Currency = change;

    Console.WriteLine();
}