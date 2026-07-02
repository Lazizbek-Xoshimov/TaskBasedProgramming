using System.Diagnostics;
using StudentInformationSystem.Services;

namespace StudentInformationSystem;

public class Program
{
    public static async Task Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        StudentService studentService = new StudentService();

        stopwatch.Start();
        Task<string> taskFirst = studentService.GetStudentNameAsync();
        Task<int> taskSecond = studentService.GetStudentGradeAsync();
        Task<int> taskThird = studentService.GetStudentAttendanceAsync();

        Console.WriteLine();
        Console.WriteLine($"Name: {await taskFirst}");
        Console.WriteLine($"Grade: {await taskSecond}");
        Console.WriteLine($"Attendance: {await taskThird} %");
        stopwatch.Stop();

        Console.WriteLine($"\nMain Thread finished in {stopwatch.ElapsedMilliseconds / 1000.0} seconds.");
    }
}