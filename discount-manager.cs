namespace Store
{
    public class DiscountManager
    {
        public enum AccountType
        {
            NewCustomer = 1,
            RecentCustomer = 2,
            PlatinumCustomer = 3,
            LoyalCustomer = 4
        }

        private static IAccountTypeDiscountStrategy GetAccountTypeImplementation(AccountType accountType)
        {
            IAccountTypeDiscountStrategy accountTypeDiscountStrategy = null;

            switch (accountType)
            {
                case AccountType.NewCustomer:
                    accountTypeDiscountStrategy = 0m;              
                    break;
                case AccountType.RecentCustomer:
                    accountTypeDiscountStrategy = 0.1m;
                    break;
                case AccountType.PlatinumCustomer:
                    accountTypeDiscountStrategy = 0.7m;
                    break;
                case AccountType.LoyalCustomer:
                accountTypeDiscountStrategy = 0.5m;
                    break;
                default:
                    break;
            }
            return accountTypeDiscountStrategy;
        }

        public decimal CalculateTotalWithDiscounts(Customer customer, decimal purchaseValue)
        {
            decimal totalPurchaseValue = 0;

            decimal customerPurchaseValue = purchaseValue;

            decimal discountAccordingToAmountOfYearsAsCustomer = CalculateDiscountAccordingToYearsAsCustomer(customer.yearsAsCustomer);

            AccountType customerAccountType = customer.accountType

            discountToBeApplied = GetAccountTypeImplementation(customerAccountType);
            totalPurchaseValue = calculateSubTotal(customerPurchaseValue, discountToBeApplied, discountAccordingToAmountOfYearsAsCustomer);

            return totalPurchaseValue;
        }
        public decimal calculateSubTotal(decimal purchaseValue, decimal discount, decimal discountAccordingToAmountOfYearsAsCustomer)
        {
            if discount == 0
            {
                return purchaseValue;
            }
            discountedValue = AddDiscount(purchaseValue, discount);
            return discountedValue - discountAccordingToAmountOfYearsAsCustomer * discountedValue;
        }
        public decimal CalculateDiscountAccordingToYearsAsCustomer(decimal yearsAsCustomer)
        {
            if (yearsAsCustomer > 5)
            {
                return 0.05m;
            }
            return yearsAsCustomer/100;
        }
        public decimal AddDiscount(decimal value, decimal discount)
        {
            return value * discount;
        }
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime YearsAsCustomer { get; set; }
        public int AccountType { get; set; }
    }
}
