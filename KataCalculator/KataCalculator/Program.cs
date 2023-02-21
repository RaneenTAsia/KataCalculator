// See https://aka.ms/new-console-template for more information
using KataCalculator;
using KataCalculator.PriceCalculators;
using KataCalculator.Products;

PriceCalculatorConfigurations PriceCalculatorConfigurations = ReadPriceCalculatorConfigurations();

PriceCalculator PriceCalculator = new PriceCalculator(PriceCalculatorConfigurations);

PrintProducts(PriceCalculator);

static void PrintProducts(PriceCalculator priceCalculator)
{
    ProductViewModel ProductViewModel = new ProductViewModel();

    PriceCalculatorPrinterConfigurations priceCalculatorPrinterConfigurations = new PriceCalculatorPrinterConfigurations(priceCalculator, ReadCurrencyConfiguration());
    PriceCalculatorPrinter priceCalculatorPrinter = new PriceCalculatorPrinter(priceCalculatorPrinterConfigurations);

    foreach (var item in ProductViewModel.Products)
    {
        priceCalculatorPrinter.printCalculations(item);
        Console.WriteLine();
    }
}

static PriceCalculatorConfigurations ReadPriceCalculatorConfigurations()
{
    var taxConfiguration = ReadTaxConfiguration();

    var discountConfiguration = ReadDiscountConfigurations();

    CombinationType combinationTypeConfiguration = ReadCombinationTypeConfiguration();

    return new PriceCalculatorConfigurations(taxConfiguration, discountConfiguration, combinationTypeConfiguration);
}

static decimal? ReadTaxConfiguration()
{
    Console.WriteLine("Specify Tax:");
    decimal? tax = ReadAndParseDecimalInput();

    Console.WriteLine();

    return tax;
}

static decimal? ReadDiscountConfigurations()
{
    Console.WriteLine("Specify general discount");
    decimal? discount = ReadAndParseDecimalInput();

    Console.WriteLine();

    return discount;
}

static decimal? ReadAndParseDecimalInput()
{
    string? input = Console.ReadLine();
    return string.IsNullOrEmpty(input) ? null : Decimal.Parse(input);
}

static CombinationType ReadCombinationTypeConfiguration()
{
    Console.WriteLine("Enter Additive or Multiplicative for Discount Combining Method:");
    string? input = Console.ReadLine();
    Console.WriteLine();

    if (string.IsNullOrEmpty(input) || input.ToLower().Equals("additive"))
    {
        return CombinationType.Additive;
    }
    else
    {
        return CombinationType.Multiplicative;
    }
}

static string ReadCurrencyConfiguration()
{
    Console.WriteLine("Specify Currency");
    string? input = Console.ReadLine();

    if (input != null)
    {
        if (input.Length > 3)
        {
            input = input.Substring(0, 3);
        }
        return input.ToUpper();
    }

    return "";
}
