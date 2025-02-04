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
    }
}
