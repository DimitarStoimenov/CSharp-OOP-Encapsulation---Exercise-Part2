using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {

           
            try
            {
                Dictionary<string, Person> persons = new Dictionary<string, Person>();
                Dictionary<string, Product> products = new Dictionary<string, Product>();
                string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < input.Length; i++)
                {
                    string[] rawInput = input[i].Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string name = rawInput[0];
                    decimal money = decimal.Parse(rawInput[1]);

                    Person person = new Person(name, money);
                    persons.Add(person.Name, person);
                }

                string[] inputProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < inputProducts.Length; i++)
                {
                    string[] rawInputProducts = inputProducts[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = rawInputProducts[0];
                    decimal cost = decimal.Parse(rawInputProducts[1]);
                    Product product = new Product(name, cost);
                    products.Add(product.Name, product);
                }
                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] rawByingCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Person buyerName = persons[rawByingCommand[0]];
                    Product productBuyer = products[rawByingCommand[1]];

                    if (buyerName.Money - productBuyer.Cost < 0)
                    {
                        Console.WriteLine($"{buyerName.Name} can't afford {productBuyer.Name}");
                        command = Console.ReadLine();
                        continue;
                       
                    }
                    buyerName.AddProduct(productBuyer);
                    Console.WriteLine($"{buyerName.Name} bought {productBuyer.Name}");
                    command = Console.ReadLine();
                }

                foreach (var item in persons)
                {
                    if (item.Value.BagOfProducts.Count == 0)
                    {
                        Console.WriteLine($"{item.Key} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value.BagOfProducts.Select(x => x.Name))}");
                    }

                }


            }
            catch (ArgumentException ae)
            {
                
                Console.WriteLine(ae.Message);
                
                
            }
        }
    }
}
