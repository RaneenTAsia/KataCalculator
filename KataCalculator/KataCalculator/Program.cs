// See https://aka.ms/new-console-template for more information
using KataCalculator;
using KataCalculator.Discounts;
using KataCalculator.Products;

PriceCalculator PriceCalculator = new PriceCalculator();

ChangeDefaultTaxAndDiscount(PriceCalculator);

PrintProducts(PriceCalculator);

static void PrintProducts(PriceCalculator priceCalculator)
{
    ProductViewModel ProductViewModel = new ProductViewModel();
    foreach (var item in ProductViewModel.Products)
    {
        priceCalculator.printCalculations(item);
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

    Console.WriteLine("Specify general discount");
    decimal? discount = CheckDecimalInput();

    if (tax != null)
        priceCalculator.TaxPercent = (decimal)tax;
    if (discount != null)
        priceCalculator.DiscountPercent = (decimal)discount;
    Console.WriteLine();
}
