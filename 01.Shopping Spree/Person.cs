using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfproducts;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfproducts = new List<Product>();
        }
        
        public string Name 
        {
            get 
            { 
                return this.name; 
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                    
                }

                this.name = value;
            } 
        }
        public decimal Money 
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> BagOfProducts => this.bagOfproducts;

        public void AddProduct(Product product)
        {
            this.Money -= product.Cost;
            this.bagOfproducts.Add(product);
            
        }
    }
}
