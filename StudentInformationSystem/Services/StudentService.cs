using StudentInformationSystem.Models;

namespace StudentInformationSystem.Services;

public class StudentService
{
    private Student student = GenerateStudent();
    private static Random random = new Random();

    public static Student GenerateStudent()
    {
        Student randomStudent = new Student();

        string[] names = 
        [
            "Azim",
            "Kamron",
            "Jasur",
            "Bekzod",
            "Shohrux",
            "Miron",
            "Davron",
            "Temur",
            "Sanjar",
            "Elyor"
        ];

        randomStudent.Name = names[random.Next(0, 10)];
        randomStudent.Grade = random.Next(1, 5);
        randomStudent.AttandanceRate = random.Next(1, 100);

        return randomStudent;
    }

    public async Task<string> GetStudentNameAsync()
    {
        Console.WriteLine("Name is being reviewed...");
        await Task.Delay(2000);

        return student.Name;
    }

    public async Task<int> GetStudentGradeAsync()
    {
        Console.WriteLine("Grade is being reviewed...");
        await Task.Delay(3000);
        
        return student.Grade;
    }

    public async Task<int> GetStudentAttendanceAsync()
    {
        Console.WriteLine("Attendance is being reviewed...");
        await Task.Delay(4000);

        return student.AttandanceRate;
    }
}