using ConsoleApp1.Models;
using ConsoleApp1.Services;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1;

internal class Program
{
    private static string student1UserName = "student1";
    private static string student1Password = "student1";

    private static string student2UserName = "student2";
    private static string student2Password = "student2";

    private static string teacherUserName = "teacher";
    private static string teacherPassword = "teacher";

    private static string directorUserName = "director";
    private static string directorPassword = "director";

    public static void done()
    {
        Console.Write("\nDone");
        Thread.Sleep(1500);
        Console.Clear();
    }
    static void Main(string[] args)
    {
        while (true)
        {
        again:
            Console.WriteLine("--------------- Log in ---------------");
            Console.WriteLine();
            Console.Write("Enter UserName: ");
            var userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            var password = Console.ReadLine();

            if (userName == "student1" && password == "student1")
            {
                //var tests = new TestService();
                //Console.WriteLine("Salom, Student1");
                //Console.WriteLine();
                //Console.WriteLine("1. Test ishlash");
                //Console.WriteLine("2. Tarixni ko'rish");
                //Console.WriteLine();
                //Console.WriteLine("0. LogInga o'tishi");
                //Console.WriteLine();
                //Console.Write("Enter option: ");
                //var option = int.Parse(Console.ReadLine());
                //if (option == 0)
                //{
                //    Console.Clear();
                //    goto again;
                //}
                //else if (option == 1)
                //{
                //    Console.Write("Nechta test yechasiz: ");
                //    var amount = int.Parse(Console.ReadLine());
                //    Console.WriteLine();
                //    var testsList = tests.GetRandomTest(amount);
                //    var countTest = 1;
                //    foreach (var test in testsList)
                //    {
                //        var testInfo = $"{countTest}: {test.Question} \nA: {test.AVariant} \nB: {test.BVariant} \nC: {test.CVariant}";
                //        Console.WriteLine(testInfo);
                //    }
                //}
                //else if (option == 2)
                //{

                //}
            }
            else if (userName == "student2" && password == "student2")
            {

            }
            else if (userName == "teacher" && password == "teacher")
            {

            }
            else if (userName == "director" && password == "director")
            {
                // Teacher Crud
                var teacherService = new TeacherService();
                Console.Clear();
                backDirectorPanel:
                Console.WriteLine("Salom, Director!");
                Console.WriteLine();
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Get Teacher");
                Console.WriteLine("3. Get by id Teacher");
                Console.WriteLine("4. Update Teacher");
                Console.WriteLine("5. Delete Teacher");
                Console.WriteLine("\nBack (0)");
                Console.WriteLine();
                Console.Write("Enter option: ");
                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.Clear();
                    var teacher = new Teacher();
                    Console.WriteLine("--------------- Teacher About ---------------");
                    Console.WriteLine();
                    Console.Write("First Name: ");
                    teacher.FirstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    teacher.LastName = Console.ReadLine();
                    Console.Write("Age Name: ");
                    teacher.Age = int.Parse(Console.ReadLine());
                    Console.Write("Subject: ");
                    teacher.Subject = Console.ReadLine();
                    Console.Write("Gender: ");
                    teacher.Gender = Console.ReadLine();

                    teacherService.AddTeacher(teacher);
                    
                    done();
                    goto backDirectorPanel;
                }
                else if (option == 2)
                {
                    Console.Clear();
                    var teachers = teacherService.GetAllTeachers();
                    var count = 1;
                    Console.WriteLine("--------------- O'qituvchilar ro'yxati ---------------\n");
                    foreach (var teacher in teachers)
                    {
                        var teacherInfo = $"{count}) First Name: {teacher.FirstName} \nLast Name: {teacher.LastName} \nSubject: {teacher.Subject} \nAge: {teacher.Age} \nGender: {teacher.Gender}";
                        Console.WriteLine($"{teacherInfo} \n");
                        count++;
                    }
                    Console.Write("\nBack (0): ");
                    var optionBack = int.Parse(Console.ReadLine());
                    if (optionBack == 0)
                    {
                        Console.Clear();
                        goto backDirectorPanel;
                    }
                }
                else if (option == 3)
                {
                    Console.Clear();
                    Console.Write("Enter get Id: ");
                    var id = Guid.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("--------------- Teacher ---------------\n");
                    var teacher = teacherService.GetByIdTeacher(id);
                    var teacherInfo = $"First Name: {teacher.FirstName} \nLast Name: {teacher.LastName} \nSubject: {teacher.Subject} \nAge: {teacher.Age} \nGender: {teacher.Gender}";
                    Console.WriteLine(teacherInfo);
                    Console.Write("\nBack (0): ");
                    var optionBack = int.Parse(Console.ReadLine());
                    if (optionBack == 0)
                    {
                        Console.Clear();
                        goto backDirectorPanel;
                    }
                }
                else if (option == 4)
                {
                    Console.Clear();
                    var newTeacher = new Teacher();
                    Console.WriteLine("--------------- Teacher About ---------------");
                    Console.WriteLine();
                    Console.Write("Enter Id: ");
                    newTeacher.Id = Guid.Parse(Console.ReadLine());
                    Console.Write("First Name: ");
                    newTeacher.FirstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    newTeacher.LastName = Console.ReadLine();
                    Console.Write("Age Name: ");
                    newTeacher.Age = int.Parse(Console.ReadLine());
                    Console.Write("Subject: ");
                    newTeacher.Subject = Console.ReadLine();
                    Console.Write("Gender: ");
                    newTeacher.Gender = Console.ReadLine();

                    var request = teacherService.UpdateTeacher(newTeacher);
                    if (request is true)
                    {
                        done();
                        goto backDirectorPanel;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Xatolik!!!\n");
                        Console.ResetColor();
                        Console.Write("Orqaga qaytish uchun xohlagan tugmani bosing: ");
                        //Thread.Sleep(1000);
                        Console.ReadLine();
                        Console.Clear();
                        goto backDirectorPanel;
                    }
                }
                else if (option == 5)
                {
                    Console.Clear();
                    Console.WriteLine("--------------- Teacher Delete ---------------");
                    Console.WriteLine();
                    Console.Write("Enter Id: ");
                    var deleteId = Guid.Parse(Console.ReadLine());
                    teacherService.DeleteTeacher(deleteId);
                    Console.Write("\nDone");
                    Thread.Sleep(1500);
                    Console.Clear();
                    goto backDirectorPanel;
                }
                else if (option == 0)
                {
                    Console.Clear();
                    goto again;
                }
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bunday foydalanuvchi mavjud emas!!!\n");
                Console.ResetColor();
                Console.Write("Qayta kirish uchun xohlagan tugmani bosing:");
                //Thread.Sleep(1000);
                Console.ReadLine();
                Console.Clear();
                goto again;
            }
        }
    }
}