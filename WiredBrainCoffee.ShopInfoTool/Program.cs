using System;
using System.Linq;
using WiredBrainCoffee.DataAccess;

namespace WiredBrainCoffee.ShopInfoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wired Brain Coffee - Shop Info Tool!");

            Console.WriteLine("Write 'help' to list available coffee shop commands, " +
                                "write 'quit' to exit app.");

            var coffeeShopDataProvider = new CoffeeShopDataProvider();

            while(true) {
                var line = Console.ReadLine();
                if(string.Equals("quit", line, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();
                if(string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee shop commands:");
                    foreach(var coffeShop in coffeeShops)
                    {
                        Console.WriteLine($"> " + coffeShop.Location);
                    }
                }
                else
                {
                    var foundCoffeeShops = coffeeShops
                                            .Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase))
                                            .ToList();
                    if(foundCoffeeShops.Count == 0)
                    {
                        Console.WriteLine($"> Command '{line}' not found");
                    }
                    else if(foundCoffeeShops.Count == 1)
                    {
                        var coffeShop = foundCoffeeShops.Single();
                        Console.WriteLine($"> Location: {coffeShop.Location}");
                        Console.WriteLine($"> Beans in stock: {coffeShop.BeansInStockInKg} kg");
                    }
                    else
                    {
                        Console.WriteLine($"> Multiple matching coffee shop commands found:");
                        foreach (var coffeeType in foundCoffeeShops)
                        {
                            Console.WriteLine($"> {coffeeType.Location}");
                        }
                    }
                }
            }
        }
    }
}
