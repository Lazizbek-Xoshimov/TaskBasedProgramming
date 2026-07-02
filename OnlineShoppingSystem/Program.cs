namespace OnlineShoppingSystem;

public class Program
{
    public static Random random = new Random();

    public static async Task Main(string[] args)
    {
        Console.Write("Enter your user name: ");
        string name = Console.ReadLine();

        var isUserExists = await ValidateUserAsync(name);
        
        if (isUserExists)
        {
            var taskCheckStock = CheckProductStockAsync();
            var taskCalculateDiscount = CalculateDiscountAsync();
            var taskCalculateShipping = CalculateShippingAsync();

            await Task.WhenAll(taskCheckStock, taskCalculateDiscount, taskCalculateShipping);

            Console.WriteLine("User: Valid");
            Console.WriteLine($"Stock: {taskCheckStock.Result}");
            Console.WriteLine($"Discount: {taskCalculateDiscount.Result} %");
            Console.WriteLine($"Shipping: ${taskCalculateShipping.Result}");

            Console.WriteLine("Order is ready.");
        }
        else
            Console.WriteLine("User: Not valid");
    }

    public static async Task<bool> ValidateUserAsync(string name)
    {
        Console.WriteLine("User is being verified...");
        await Task.Delay(2000);

        return name.Equals("admin");
    }

    public static async Task<string> CheckProductStockAsync()
    {
        Console.WriteLine("Product is checking...");
        await Task.Delay(2000);
        Console.WriteLine("Stock finished");

        return "Available";
    }

    public static async Task<int> CalculateDiscountAsync()
    {
        Console.WriteLine("Discount of product is calculating...");
        await Task.Delay(2000);
        Console.WriteLine("Discount finished");

        return random.Next(1, 100);
    }

    public static async Task<int> CalculateShippingAsync()
    {
        Console.WriteLine("Calculating shipping cost...");
        await Task.Delay(2000);
        Console.WriteLine("Shipping finished");

        return random.Next(1, 10);
    }
}