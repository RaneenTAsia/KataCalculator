// See https://aka.ms/new-console-template for more information
using KataCalculator;
Console.WriteLine("Specify Tax:");

decimal tax = Decimal.Parse(Console.ReadLine()) ;


ProductViewModel view = new ProductViewModel();

PrintProducts(view, tax);

static void PrintProducts(ProductViewModel view, decimal tax)
{
    TaxCalculations.ChangeTax(tax);
    view.GetAll();
    foreach (var item in view.Products)
    {
        Console.WriteLine(item.ToString());
        TaxCalculations calc = new TaxCalculations(item);
        Console.WriteLine($"Product price reported as ${item.BasePrice} before tax and ${calc.TaxedPrice} after {calc.TaxPercent}% tax.");
        Console.WriteLine();
    }
}

