// See https://aka.ms/new-console-template for more information
using KataCalculator;
using KataCalculator.Caps;
using KataCalculator.Discounts;
using KataCalculator.Expenses;
using KataCalculator.PriceCalculators;
using KataCalculator.Products;

PriceCalculatorConfigurations PriceCalculatorConfigurations = GetPriceCalculatorConfigurations();

PriceCalculator PriceCalculator = new PriceCalculator(PriceCalculatorConfigurations);

PrintProducts(PriceCalculator);

static void PrintProducts(PriceCalculator priceCalculator)
{
    IProductRepository productRepository = new ProductRepository();
    ProductService ProductService = new ProductService(productRepository);

    PriceCalculatorPrinterConfigurations priceCalculatorPrinterConfigurations = GetPriceCalculatorPrinterConfigurations(priceCalculator);
    PriceCalculatorPrinter priceCalculatorPrinter = new PriceCalculatorPrinter(priceCalculatorPrinterConfigurations);

    foreach (var item in ProductService.GetAll())
    {
        priceCalculatorPrinter.printCalculations(item);
        Console.WriteLine();
    }
}

static PriceCalculatorPrinterConfigurations GetPriceCalculatorPrinterConfigurations(PriceCalculator priceCalculator)
{
    IExpenseRepository expenseRepository = new ExpenseRepository();
    ExpenseService expenseService = new ExpenseService(expenseRepository);

    ICapRepository capRepository = new CapRepository();
    CapService capService = new CapService(capRepository);

    String currency = ReadCurrencyConfiguration();

    return new PriceCalculatorPrinterConfigurations(priceCalculator, currency, expenseService, capService);
}

static PriceCalculatorConfigurations GetPriceCalculatorConfigurations()
{
    var taxConfiguration = ReadTaxConfiguration();

    var discountConfiguration = ReadDiscountConfigurations();

    CombinationType combinationTypeConfiguration = ReadCombinationTypeConfiguration();

    IDiscountRepository discountRepository = new DiscountRepository();
    SelectiveDiscountService selectiveDiscountService = new SelectiveDiscountService(discountRepository);

    return new PriceCalculatorConfigurations(taxConfiguration, discountConfiguration, combinationTypeConfiguration,selectiveDiscountService);
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
