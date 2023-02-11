using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataCalculator.Discounts;
using KataCalculator.Expenses;
using KataCalculator.Products;

namespace KataCalculator
{
    public class PriceCalculator
    {
        public decimal TaxPercent { get; set; } = 20M;
        public decimal DiscountPercent { get; set; } = 0M;
        public SelectiveDiscountViewModel SelectiveDiscountViewModel { get; set; }
        public ExpenseViewModel ExpenseViewModel { get; set; }

        public PriceCalculator()
        {
            SelectiveDiscountViewModel = new SelectiveDiscountViewModel();
            ExpenseViewModel = new ExpenseViewModel();
        }

        public decimal CalculateTaxValue(Product product)
        {
            if (IsPrecedenceDiscount(product))
                return ((product.BasePrice - CalculateUPCDiscount(product)) * (TaxPercent / 100)).DecimalPlaces(2);
            else
                return (product.BasePrice * (TaxPercent / 100)).DecimalPlaces(2);
        }

        private bool IsPrecedenceDiscount(Product product)
        {
            SelectiveDiscount? discount = SelectiveDiscountViewModel.FindUPCDiscount(product.UPC);
            return discount != null && discount.DiscountType == DiscountType.Precedence;
        }

        public decimal CalculateDiscount(Product product)
        {
            return (DiscountPercent / 100 * product.BasePrice).DecimalPlaces(2);
        }

        public decimal CalculateUPCDiscount(Product product)
        {
            decimal? UPCDiscount = 0M;
            if (SelectiveDiscountViewModel.FindUPCDiscount(product.UPC)!=null)
            UPCDiscount=SelectiveDiscountViewModel.FindUPCDiscount(product.UPC).DiscountPercent;
            if(UPCDiscount != 0)
            return ((decimal)UPCDiscount / 100 * product.BasePrice).DecimalPlaces(2);
            else
            return 0;

        }

        public decimal AccumulativeDiscountAmount(Product product)
        {
            return CalculateUPCDiscount(product) + CalculateDiscount(product);
        }

        public decimal CalculateTotalPrice(Product product,decimal ExpenseSum)
        {
            decimal value= product.BasePrice+ CalculateTaxValue(product)-AccumulativeDiscountAmount(product)+ExpenseSum;
            return value;
        }

        public void printCalculations(Product product)
        {
            decimal ExpenseSum = 0;
            Console.WriteLine(product.ToString());
            Console.WriteLine($"Tax={TaxPercent}%, " +
            $"Tax amount=${CalculateTaxValue(product)}, Discount amount=${AccumulativeDiscountAmount(product)}");
            foreach(Expense expense in ExpenseViewModel.FindUPCExpense(product.UPC))
            {
                if (expense.ExpenseType == ExpenseType.Percent)
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
            Console.WriteLine($"Price before = ${product.BasePrice}, price after = ${CalculateTotalPrice(product,ExpenseSum).DecimalPlaces(2)}");

        }

        private static decimal CalculatePercentExpenseValue(Product product, Expense expense)
        {
            return expense.Amount * product.BasePrice;
        }
    }
}
