namespace WiredBrainCoffee.DataAccess
{
    public class CoffeeShopDataProvider
    {
        public IEnumerable<CoffeeShop> LoadCoffeeShops() {
            yield return new CoffeeShop { Location = "Frankfurt", BeansInStickInKg = 107 };
            yield return new CoffeeShop { Location = "Freiburg", BeansInStickInKg = 23 };
            yield return new CoffeeShop { Location = "Munich", BeansInStickInKg = 56 };
        }
    }
}