using System.Diagnostics;

namespace FastestDelivery;

public class Program
{
    public static async Task Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        Task<string> taskByCar = DeliveryByCar();
        Task<string> taskByBike = DeliveryByBike();
        Task<string> taskByDrone = DeliveryByDrone();

        var fastest = await Task.WhenAny<string>(taskByCar, taskByBike, taskByDrone);

        await Task.WhenAll(taskByCar, taskByBike, taskByDrone);

        Console.WriteLine();
        Console.WriteLine($"Fastest vehicle: {fastest.Result}");
        stopwatch.Stop();

        Console.WriteLine($"\nMain Thread finished in {stopwatch.ElapsedMilliseconds / 1000.0} seconds.");
    }

    public static async Task<string> DeliveryByCar()
    {
        Console.WriteLine("It set out in a Delivery by Car...");
        await Task.Delay(2000);
        Console.WriteLine("Delivery by Car has arrived.");
        return "Delivery by Car";
    }

    public static async Task<string> DeliveryByBike()
    {
        Console.WriteLine("It set out in a Delivery by Bike...");
        await Task.Delay(4000);
        Console.WriteLine("Delivery by Bike has arrived.");
        return "Delivery by Bike";
    }

    public static async Task<string> DeliveryByDrone()
    {
        Console.WriteLine("It set out in a Delivery by Drone...");
        await Task.Delay(6000);
        Console.WriteLine("Delivery by Drone has arrived.");
        return "Delivery by Drone";
    }
}