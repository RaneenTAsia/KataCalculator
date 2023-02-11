using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataCalculator.Caps;
using KataCalculator.Discounts;
using KataCalculator.Expenses;
using KataCalculator.Products;

namespace KataCalculator
{
    public class PriceCalculator
    {
        public decimal TaxPercent { get; set; } = 21M;
        public decimal DiscountPercent { get; set; } = 15M;
        public SelectiveDiscountViewModel SelectiveDiscountViewModel { get; set; }
        public ExpenseViewModel ExpenseViewModel { get; set; }
        public CapViewModel CapViewModel { get; set; }

        public PriceCalculator()
        {
            SelectiveDiscountViewModel = new SelectiveDiscountViewModel();
            ExpenseViewModel = new ExpenseViewModel();
            CapViewModel = new CapViewModel();
        }

        public decimal CalculateTaxValue(Product product)
        {
            if (IsPrecedenceDiscount(product))
                return ((product.BasePrice - CalculateUPCDiscount(product.UPC,product.BasePrice)) * (TaxPercent / 100)).DecimalPlaces(2);
            else
                return (product.BasePrice * (TaxPercent / 100M));
        }

        private bool IsPrecedenceDiscount(Product product)
        {
            SelectiveDiscount? discount = SelectiveDiscountViewModel.FindUPCDiscount(product.UPC);
            return discount != null && discount.DiscountType == DiscountType.Precedence;
        }

        public decimal CalculateDiscount(Product product)
        {
            return DiscountPercent / 100M * product.BasePrice;
        }

        public decimal CalculateUPCDiscount(int UPC, decimal BasePrice)
        {
            decimal? UPCDiscount = 0M;
            if (SelectiveDiscountViewModel.FindUPCDiscount(UPC)!=null)
            UPCDiscount=SelectiveDiscountViewModel.FindUPCDiscount(UPC).DiscountPercent;

            if(UPCDiscount != 0)
            return ((decimal)UPCDiscount / 100M * BasePrice);
            else
            return 0;
        }

        public decimal AccumulativeDiscountAmount(Product product)
        {
            return CalculateUPCDiscount(product.UPC,product.BasePrice) + CalculateDiscount(product);
        }

        public decimal MultiplicativeDiscountAmount(Product product)
        {
            decimal generalDiscount=CalculateDiscount(product);
            decimal generalDiscountedPrice = product.BasePrice - generalDiscount;
            return generalDiscount + CalculateUPCDiscount(product.UPC,generalDiscountedPrice);
        }

        public decimal DiscountAmount(Product product, CombinationType combinationType,Cap cap)
        {
            decimal discountAmount;

            if(combinationType == CombinationType.Multiplicative)
            {
                discountAmount = MultiplicativeDiscountAmount(product);
            }
            else
            {
                discountAmount = AccumulativeDiscountAmount(product);
            }

            if (cap != null)
            {
                decimal capAmount = CalculateCapAmount(product, cap);

                if (discountAmount > capAmount)
                {
                    discountAmount = capAmount;
                }
            }

            return discountAmount;
        }

        public decimal CalculateTotalPrice(Product product,decimal ExpenseSum, CombinationType combinationType, Cap cap)
        {
                return product.BasePrice + CalculateTaxValue(product) - DiscountAmount(product,combinationType, cap) + ExpenseSum;   
        }

        private static decimal CalculatePercentExpenseValue(Product product, Expense expense)
        {
            return expense.Amount * product.BasePrice;
        }

        public void printCalculations(Product product,CombinationType combinationType)
        {
            decimal ExpenseSum = 0;
            Cap cap=CapViewModel.FindUPCCap(product.UPC);
            Console.WriteLine(product.ToString());
            Console.WriteLine($"Tax={TaxPercent.DecimalPlaces(2)}%, " +
                $"Tax amount=${CalculateTaxValue(product).DecimalPlaces(2)}, Discount amount=${DiscountAmount(product,combinationType,cap).DecimalPlaces(2)}");
            foreach(Expense expense in ExpenseViewModel.FindUPCExpense(product.UPC))
            {
                if (expense.ExpenseType == RelativeType.Percent)
                {
                    decimal ExpenseValue = CalculatePercentExpenseValue(product, expense);
                    Console.WriteLine(expense.Description+": $"+ExpenseValue.DecimalPlaces(2));
                    ExpenseSum += ExpenseValue;
                }
                else
                {
                    Console.WriteLine(expense.ToString());
                    ExpenseSum += expense.Amount;
                }
            }
            Console.WriteLine($"Price before = ${product.BasePrice.DecimalPlaces(2)}, price after = ${CalculateTotalPrice(product,ExpenseSum,combinationType,cap).DecimalPlaces(2)}");

        }

        public decimal CalculateCapAmount(Product product, Cap cap)
        {
            if (cap.RelativeType == RelativeType.Absolute)
            {
                return cap.Value;
            }
            else 
            {
                return product.BasePrice * (cap.Value/100);
            }
        }
    }
}
