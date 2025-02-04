using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public class Product
    {
        public int ProdID { get; private set; }
        public string ProdName { get; private set; }
        public decimal ItemPrice { get; private set; }
        public int StockAmount { get; private set; }

        public Product(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            ValidateProductID(prodID);
            ValidateProductName(prodName);
            ValidatePrice(itemPrice);
            ValidateStock(stockAmount);

            this.ProdID = prodID;
            this.ProdName = prodName;
            this.ItemPrice = itemPrice;
            this.StockAmount = stockAmount;
        }

        public void IncreaseStock(int amount)
        {
            if (amount > 0)
            {
                this.StockAmount += amount;
            }
            else
            {
                throw new ArgumentException("Increase amount must be greater than zero.");
            }
        }

        public void DecreaseStock(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Decrease amount must be greater than zero.");
            }

            if (this.StockAmount >= amount)
            {
                this.StockAmount -= amount;
            }
            else
            {
                throw new InvalidOperationException("Stock cannot be negative.");
            }
        }

        private void ValidateProductID(int id)
        {
            if (id < 8 || id > 80000)
            {
                throw new ArgumentException("Product ID must be between 8 and 80000.");
            }
        }

        private void ValidateProductName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Trim().Length == 0)
            {
                throw new ArgumentNullException(nameof(name), "Product name cannot be null or empty.");
            }
        }

        private void ValidatePrice(decimal price)
        {
            if (price < 8 || price > 8000)
            {
                throw new ArgumentException("Item Price must be between $8 and $8000.");
            }
        }

        private void ValidateStock(int stock)
        {
            if (stock < 8 || stock > 800000)
            {
                throw new ArgumentException("Stock Amount must be between 8 and 800000.");
            }
        }
    }
}
