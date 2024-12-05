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
                Console.WriteLine("Salom, Student1");
                Console.WriteLine();
                Console.WriteLine("1. Test yechish");


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