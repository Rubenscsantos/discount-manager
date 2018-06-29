using System;

namespace Store
{
    public enum AccountType
    {
        NewCustomer = 1,
        RecentCustomer = 2,
        PlatinumCustomer = 3,
        LoyalCustomer = 4
    }

    public class DiscountManager
    {
        private decimal GetAccountTypeImplementation(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.RecentCustomer:
                    return 0.1m;
                case AccountType.PlatinumCustomer:
                    return 0.7m;
                case AccountType.LoyalCustomer:
                    return 0.5m;
                default:
                    return 0m;
            }
        }

        public decimal CalculateTotalWithDiscounts(Customer customer, decimal purchaseValue)
        {
            decimal totalPurchaseValue = 0;

            decimal customerPurchaseValue = purchaseValue;

            decimal discountAccordingToAmountOfYearsAsCustomer = CalculateDiscountAccordingToYearsAsCustomer(customer.YearsAsCustomer);

            AccountType customerAccountType = customer.AccountType;

            decimal discountToBeApplied = GetAccountTypeImplementation(customerAccountType);
            totalPurchaseValue = calculateSubTotal(customerPurchaseValue, discountToBeApplied, discountAccordingToAmountOfYearsAsCustomer);

            return totalPurchaseValue;
        }
        public decimal calculateSubTotal(decimal purchaseValue, decimal discount, decimal discountAccordingToAmountOfYearsAsCustomer)
        {
            if (discount == 0)
            {
                return purchaseValue;
            }
            decimal discountedValue = AddDiscount(purchaseValue, discount);
            return discountedValue - discountAccordingToAmountOfYearsAsCustomer * discountedValue;
        }
        public decimal CalculateDiscountAccordingToYearsAsCustomer(decimal yearsAsCustomer)
        {
            if (yearsAsCustomer > 5)
            {
                return 0.05m;
            }
            return yearsAsCustomer / 100;
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
        public int YearsAsCustomer { get; set; }
        public AccountType AccountType { get; set; }


        public Customer(string firstName, string lastName, int yearsAsCustomer, AccountType accountType)
        {
            FirstName = firstName;
            LastName = lastName;
            YearsAsCustomer = yearsAsCustomer;
            AccountType = accountType;
        }
    }
}
