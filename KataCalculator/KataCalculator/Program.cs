// See https://aka.ms/new-console-template for more information
using KataCalculator;

ChangeDefaultTaxAndDiscount();

SelectiveDiscountList DiscountList = NewMethod();

ProductViewModel view = new ProductViewModel();
PrintProducts(view, DiscountList);

static void PrintProducts(ProductViewModel view, SelectiveDiscountList DiscountList)
{
    view.GetAll();
    foreach (var item in view.Products)
    {
        PriceCalculator calculator = new PriceCalculator(item, DiscountList);
        Console.WriteLine(item.ToString());
        Console.WriteLine($"Tax={PriceCalculator.TaxPercent}%, discount={PriceCalculator.DiscountPercent}%, " +
            $"Tax amount=${calculator.CalculateTaxValue()}, Discount amount=${calculator.AccumulativeDiscountAmount()}");
        Console.WriteLine($"Price before = ${item.BasePrice}, price after = ${calculator.CalculateGeneralDiscountedAndTaxedPrice()}");
        Console.WriteLine();
    }
}

static decimal? CheckDecimalInput()
{
    string input = Console.ReadLine();
    return string.IsNullOrEmpty(input) ? null : Decimal.Parse(input);
}
static Int32? CheckIntInput()
{
    string input = Console.ReadLine();
    return string.IsNullOrEmpty(input) ? null : Int32.Parse(input);
}

static SelectiveDiscountList NewMethod()
{
    SelectiveDiscountList DiscountList = new SelectiveDiscountList();

    int? UPC = 1;
    decimal? discountRate = 1M;
    while (discountRate != null)
    {
        Console.WriteLine("Give UPC and UPC Discount Rate");
        UPC = CheckIntInput();
        if (UPC == null)
            break;
        discountRate = CheckDecimalInput();
        if (UPC != null && discountRate != null)
            DiscountList.AddDiscount(new SelectiveDiscount((Int32)UPC, (decimal)discountRate));
    }

    return DiscountList;
}

static void ChangeDefaultTaxAndDiscount()
{
    Console.WriteLine("Specify Tax:");
    decimal? tax = CheckDecimalInput();

    Console.WriteLine("Specify general discount");
    decimal? discount = CheckDecimalInput();

    if (tax != null)
        PriceCalculator.TaxPercent = (decimal)tax;
    if (discount != null)
        PriceCalculator.DiscountPercent = (decimal)discount;
    Console.WriteLine();
}