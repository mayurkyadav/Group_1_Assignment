using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ECommerceApplication
{
    public class ProductTest
    {

        // what it does: checks if a valid product id is assigned correctly.
        // why it was chosen: ensures normal values are stored properly.
        [Test]
        public void ProductID_ValidValue_SetsCorrectly()
        {
            // arrange
            int prodID = 500;
            string prodName = "Laptop";
            decimal itemPrice = 1200;
            int stockAmount = 50;

            // act
            var product = new Product(prodID, prodName, itemPrice, stockAmount);

            // assert
            Assert.That(product.ProdID, Is.EqualTo(prodID));
        }

        // what it does: checks if the lowest valid product id is accepted.
        // why it was chosen: verifies boundary value (minimum allowed id).
        [Test]
        public void ProductID_LowerBoundary_AcceptsValue()
        {
            // arrange
            int prodID = 8;
            string prodName = "Mouse";
            decimal itemPrice = 20;
            int stockAmount = 10;

            // act
            var product = new Product(prodID, prodName, itemPrice, stockAmount);

            // assert
            Assert.That(product.ProdID, Is.EqualTo(prodID));
        }

        // what it does: checks if a product id below the allowed range throws an error.
        // why it was chosen: ensures invalid values are rejected.
        [Test]
        public void ProductID_BelowRange_ThrowsException()
        {
            // arrange & act & assert
            Assert.Throws<ArgumentException>(() => new Product(7, "Keyboard", 50, 10));
        }



        // what it does: checks if a valid product name is stored correctly.
        // why it was chosen: ensures names are handled properly.
        [Test]
        public void ProductName_ValidValue_SetsCorrectly()
        {
            // arrange
            var product = new Product(200, "Smartphone", 800, 20);

            // assert
            Assert.That(product.ProdName, Is.EqualTo("Smartphone"));
        }

        // what it does: checks if an empty product name throws an error.
        // why it was chosen: prevents invalid data from being stored.
        [Test]
        public void ProductName_EmptyValue_ThrowsException()
        {
            // arrange & act & assert
            Assert.Throws<ArgumentNullException>(() => new Product(201, "", 400, 15));
        }

        // what it does: checks if a null product name throws an error.
        // why it was chosen: ensures null values do not cause issues.
        [Test]
        public void ProductName_NullValue_ThrowsException()
        {
            // arrange & act & assert
            Assert.Throws<ArgumentNullException>(() => new Product(202, null, 600, 10));
        }



        // what it does: checks if a valid item price is stored correctly.
        // why it was chosen: verifies prices within the allowed range.
        [Test]
        public void ItemPrice_ValidValue_SetsCorrectly()
        {
            // arrange
            var product = new Product(300, "Monitor", 500, 25);

            // assert
            Assert.That(product.ItemPrice, Is.EqualTo(500));
        }

        // what it does: checks if a price below the allowed minimum throws an error.
        // why it was chosen: ensures invalid values are rejected.
        [Test]
        public void ItemPrice_BelowRange_ThrowsException()
        {
            // arrange & act & assert
            Assert.Throws<ArgumentException>(() => new Product(301, "USB Cable", 7, 15));
        }

        // what it does: checks if a price above the allowed maximum throws an error.
        // why it was chosen: prevents prices beyond limits.
        [Test]
        public void ItemPrice_AboveRange_ThrowsException()
        {
            // arrange & act & assert
            Assert.Throws<ArgumentException>(() => new Product(302, "Server", 8001, 10));
        }

        // what it does: checks if a valid stock amount is assigned correctly.
        // why it was chosen: verifies normal stock values.
        [Test]
        public void StockAmount_ValidValue_SetsCorrectly()
        {
            // arrange
            var product = new Product(400, "Chair", 100, 100);

            // assert
            Assert.That(product.StockAmount, Is.EqualTo(100));
        }

        // what it does: checks if stock below the minimum allowed throws an error.
        // why it was chosen: prevents invalid stock values.
        [Test]
        public void StockAmount_BelowRange_ThrowsException()
        {
            // arrange & act & assert
            Assert.Throws<ArgumentException>(() => new Product(401, "SSD", 100, 7));
        }

        // what it does: checks if stock above the maximum allowed throws an error.
        // why it was chosen: ensures excessive stock is rejected.
        [Test]
        public void StockAmount_AboveRange_ThrowsException()
        {
            // arrange & act & assert
            Assert.Throws<ArgumentException>(() => new Product(403, "HDD", 150, 800001));
        }



        // what it does: checks if stock increases correctly with a valid amount.
        // why it was chosen: ensures stock updates properly.
        [Test]
        public void IncreaseStock_ValidValue_UpdatesStock()
        {
            // arrange
            var product = new Product(500, "Tablet", 500, 30);
            int increaseAmount = 10;

            // act
            product.IncreaseStock(increaseAmount);

            // assert
            Assert.That(product.StockAmount, Is.EqualTo(40));
        }

        // what it does: checks if increasing stock by zero throws an error.
        // why it was chosen: prevents invalid updates.
        [Test]
        public void IncreaseStock_ZeroValue_ThrowsException()
        {
            // arrange
            var product = new Product(501, "Phone", 999, 25);

            // act & assert
            Assert.Throws<ArgumentException>(() => product.IncreaseStock(0));
        }

        // what it does: checks if increasing stock by a large value updates correctly.
        // why it was chosen: ensures large stock increases work.
        [Test]
        public void IncreaseStock_LargeValue_UpdatesStock()
        {
            // arrange
            var product = new Product(504, "Bulk Paper", 50, 50000);
            int increaseAmount = 100000;

            // act
            product.IncreaseStock(increaseAmount);

            // assert
            Assert.That(product.StockAmount, Is.EqualTo(150000));
        }



        // what it does: checks if stock decreases correctly with a valid amount.
        // why it was chosen: ensures stock reduction works properly.
        [Test]
        public void DecreaseStock_ValidValue_UpdatesStock()
        {
            // arrange
            var product = new Product(600, "Monitor", 400, 50);
            int decreaseAmount = 20;

            // act
            product.DecreaseStock(decreaseAmount);

            // assert
            Assert.That(product.StockAmount, Is.EqualTo(30));
        }


        // what it does: checks if decreasing stock below zero throws an error.
        // why it was chosen: prevents negative stock.
        [Test]
        public void DecreaseStock_BelowZero_ThrowsException()
        {
            // arrange5
            var product = new Product(601, "Webcam", 100, 8);
            int decreaseAmount = 9;

            // act & assert
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(decreaseAmount));
        }

        // what it does: checks if reducing stock to zero works correctly.
        // why it was chosen: verifies edge case handling.
        [Test]
        public void DecreaseStock_ToZero_UpdatesStock()
        {
            // arrange
            var product = new Product(602, "Mouse", 30, 10);
            int decreaseAmount = 10;

            // act
            product.DecreaseStock(decreaseAmount);

            // assert
            Assert.That(product.StockAmount, Is.EqualTo(0));
        }
    }
}
