public class DiscountManager
    {
        public decimal CalculateTotalWithDiscounts(Customer customer)
        {
            decimal totalPurchaseValue = 0;

            decimal customerPurchaseValue = customer.purchaseValue;

            decimal discountAccordingToAmountOfYearsAsCustomer = CalculateDiscountAccordingToYearsAsCustomer(customer.yearsAsCustomer)

            if (customer.accountType == 1)
            {
                totalPurchaseValue = customerPurchaseValue;
            }
            else if (customer.accountType == 2)
            {
                totalPurchaseValue = calculateSubTotal(customerPurchaseValue, 0.1m, discountAccordingToAmountOfYearsAsCustomer)                
            }
            else if (customer.accountType == 3)
            {
                totalPurchaseValue = calculateSubTotal(customerPurchaseValue, 0.7m, discountAccordingToAmountOfYearsAsCustomer)                
            }
            else if (customer.accountType == 4)
            {
                totalPurchaseValue = calculateSubTotal(customerPurchaseValue, 0.5m, discountAccordingToAmountOfYearsAsCustomer)                
            }

            return totalPurchaseValue;
        }
        public calculateSubTotal(decimal purchaseValue, decimal discount, decimal discountAccordingToAmountOfYearsAsCustomer)
        {
            discountedValue = AddDiscount(purchaseValue, discount)
            return discountedValue - discountAccordingToAmountOfYearsAsCustomer * discountedValue;
        }
        public CalculateDiscountAccordingToYearsAsCustomer(decimal yearsAsCustomer)
        {
            if (yearsAsCustomer > 5)
            {
                return 0.05m;
            }
            return yearsAsCustomer/100;
        }
        public AddDiscount(decimal value, decimal discount)
        {
            return value * discount;
        }
    }
}