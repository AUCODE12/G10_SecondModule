using ConsoleApp1.Services;

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
                var tests = new TestService();
                Console.WriteLine("Salom, Student1");
                Console.WriteLine();
                Console.WriteLine("1. Test ishlash");
                Console.WriteLine("2. Tarixni ko'rish");
                Console.WriteLine();
                Console.WriteLine("0. LogInga o'tishi");
                Console.WriteLine();
                Console.Write("Enter option: ");
                var option = int.Parse(Console.ReadLine());
                if (option == 0)
                {
                    Console.Clear();
                    goto again;
                }
                else if (option == 1)
                {
                    Console.Write("Nechta test yechasiz: ");
                    var amount = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    var testsList = tests.GetRandomTest(amount);
                    var countTest = 1;
                    foreach (var test in testsList)
                    {
                        var testInfo = $"{countTest}: {test.Question} \nA: {test.AVariant} \nB: {test.BVariant} \nC: {test.CVariant}";
                        Console.WriteLine(testInfo);
                    }
                }
                else if (option == 2)
                {

                }
            }
            else if (userName == "student2" && password == "student2")
            {

            }
            else if (userName == "teacher" && password == "teacher")
            {

            }
            else if (userName == "director" && password == "director")
            {

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