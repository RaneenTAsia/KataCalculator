// See https://aka.ms/new-console-template for more information
using KataCalculator;

ProductViewModel view = new ProductViewModel();

PrintProducts(view);

static void PrintProducts(ProductViewModel view)
{
    view.GetAll();
    foreach (var item in view.Products)
    {
        Console.WriteLine(item.ToString());
        Console.WriteLine($"Product price reported as ${item.BasePrice} before tax and ${item.CalculateTaxValue()} after {item.TaxPercent}% tax.");
        item.TaxPercent = 30M;
        Console.WriteLine(item.ToString());
        Console.WriteLine($"Product price reported as ${item.BasePrice} before tax and ${item.TaxPrice} after {item.TaxPercent}% tax.");
        Console.WriteLine();
    }
}

