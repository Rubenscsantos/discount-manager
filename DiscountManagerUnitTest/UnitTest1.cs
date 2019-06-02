using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store;

namespace DiscountManagerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void New_customers_should_have_no_discount()
        {
            //Arrange
            DiscountManager manager = new DiscountManager();
            Customer customer = new Customer("Rubens", "Santos", 0, 0);

            //Act
            var result = manager.CalculateTotalWithDiscounts(customer, 100);

            //Assert
            Assert.AreEqual(100m, result);
        }
    }
}
