using System.Diagnostics;

namespace DownloadManager;

public class Program
{
    public static async Task Main(string[] args)
    {
        var stopwatch = new Stopwatch();

        Task taskFirst = DownloadFileFirst();
        Task taskSecond = DownloadFileSecond();
        Task taskThird = DownloadFileThird();

        await taskFirst;
        await taskSecond;
        await taskThird;
        
        stopwatch.Start();
        
        Console.WriteLine("All files have been downloaded.");
        stopwatch.Stop();

        Console.WriteLine($"\nMain thread finished in {stopwatch.ElapsedMilliseconds/1000.0} seconds.");
    }

    public static async Task DownloadFileFirst()
    {
        Console.WriteLine("First file is downloading...");
        await Task.Delay(1000);
        Console.WriteLine("First file downloaded.");
    }

    public static async Task DownloadFileSecond()
    {
        Console.WriteLine("Second file is downloading...");
        await Task.Delay(2000);
        Console.WriteLine("Second file downloaded.");
    }

    public static async Task DownloadFileThird()
    {
        Console.WriteLine("Third file is downloading...");
        await Task.Delay(3000);
        Console.WriteLine("Third file downloaded.");
    }
}