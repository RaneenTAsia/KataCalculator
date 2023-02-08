// See https://aka.ms/new-console-template for more information
using KataCalculator;
using KataCalculator.Discount;

Console.WriteLine("Specify Tax:");

decimal? tax = CheckInput();

ProductViewModel view = new ProductViewModel();

if (tax != null)
<<<<<<< Updated upstream
    ChangeTax(tax);
=======
    TaxCalculations.TaxPercent=(decimal)tax;
if (discount != null)
    Discount.DiscountPercent=(decimal)discount;
>>>>>>> Stashed changes

PrintProducts(view);

static void PrintProducts(ProductViewModel view)
{
    view.GetAll();
    foreach (var item in view.Products)
    {
        Console.WriteLine(item.ToString());
<<<<<<< Updated upstream
        TaxCalculations calc = new TaxCalculations(item);
        Console.WriteLine($"Product price reported as ${item.BasePrice} before tax and ${calc.TaxedPrice} after {calc.TaxPercent}% tax.");
=======
        Console.WriteLine($"Tax={TaxCalculations.TaxPercent}%, discount={Discount.DiscountPercent}%, " +
            $"Tax amount=${calc.CalculateTaxValue()}, Discount amount=${discount.CalculateDiscount()}");
        Console.WriteLine($"Price before =${item.BasePrice}, price after = ${calc.TaxedPrice-discount.CalculateDiscount()}");
>>>>>>> Stashed changes
        Console.WriteLine();
    }
}

<<<<<<< Updated upstream
static void ChangeTax(decimal? tax)
{
    TaxCalculations.ChangeTax((decimal)tax);
}

=======
>>>>>>> Stashed changes
static decimal? CheckInput()
{
    string input = Console.ReadLine();
    return string.IsNullOrEmpty(input) ? null : Decimal.Parse(input);
}