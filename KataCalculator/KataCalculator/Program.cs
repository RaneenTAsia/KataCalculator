// See https://aka.ms/new-console-template for more information
using KataCalculator;
Console.WriteLine("Specify Tax:");

decimal? tax = CheckInput();

ProductViewModel view = new ProductViewModel();

if (tax != null)
    ChangeTax(tax);

PrintProducts(view);

static void PrintProducts(ProductViewModel view)
{
    view.GetAll();
    foreach (var item in view.Products)
    {
        Console.WriteLine(item.ToString());
        TaxCalculations calc = new TaxCalculations(item);
        Console.WriteLine($"Product price reported as ${item.BasePrice} before tax and ${calc.TaxedPrice} after {calc.TaxPercent}% tax.");
        Console.WriteLine();
    }
}

static void ChangeTax(decimal? tax)
{
    TaxCalculations.ChangeTax((decimal)tax);
}

static decimal? CheckInput()
{
    string input = Console.ReadLine();
    return string.IsNullOrEmpty(input) ? null : Decimal.Parse(input);
}