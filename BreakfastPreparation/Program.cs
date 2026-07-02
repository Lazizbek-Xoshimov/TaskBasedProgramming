using System.Diagnostics;

namespace BreakfastPreparation;

public class Program
{
    public static async Task Main(string[] args)
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        Task taskBoilEgg = BoilEgg();
        Task taskToastBread = ToastBread();
        Task taskMakeTea = MakeTea();

        await Task.WhenAll(taskBoilEgg, taskToastBread, taskMakeTea);
        Console.WriteLine("Breakfast is ready.");
        stopwatch.Stop();

        Console.WriteLine($"\nMain thread finished in {stopwatch.ElapsedMilliseconds/1000.0} seconds.");
    }

    public static async Task BoilEgg()
    {
        Console.WriteLine("The eggs were put on to boil.");
        await Task.Delay(5000);
        Console.WriteLine("The egg is ready.");
    } 

    public static async Task ToastBread()
    {
        Console.WriteLine("The bread was put in the toaster.");
        await Task.Delay(3000);
        Console.WriteLine("The bread is ready.");
    }

    public static async Task MakeTea()
    {
        Console.WriteLine("Tea preparation has begun.");
        await Task.Delay(2000);
        Console.WriteLine("The tea is ready.");
    }
}