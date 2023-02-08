// See https://aka.ms/new-console-template for more information
using KataCalculator;
using KataCalculator.Discount;

Console.WriteLine("Specify Tax:");
decimal? tax = CheckInput();

Console.WriteLine("Specify general discount");
decimal? discount = CheckInput();

ProductViewModel view = new ProductViewModel();

if (tax != null)
    PriceCalculator.TaxPercent=(decimal)tax;
if (discount != null)
    PriceCalculator.DiscountPercent=(decimal)discount;

PrintProducts(view);

static void PrintProducts(ProductViewModel view)
{
    view.GetAll();
    foreach (var item in view.Products)
    {
        PriceCalculator calculator= new PriceCalculator(item);
        Console.WriteLine(item.ToString());
        Console.WriteLine($"Tax={PriceCalculator.TaxPercent}%, discount={PriceCalculator.DiscountPercent}%, " +
            $"Tax amount=${calculator.CalculateTaxValue()}, Discount amount=${calculator.CalculateDiscount()}");
        Console.WriteLine($"Price before =${item.BasePrice}, price after = ${calculator.TaxedPrice-calculator.CalculateDiscount()}");
        Console.WriteLine();
    }
}

static decimal? CheckInput()
{
    string input = Console.ReadLine();
    return string.IsNullOrEmpty(input) ? null : Decimal.Parse(input);
}