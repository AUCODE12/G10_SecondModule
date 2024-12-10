using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        StartFrontEnd();
    }

    public static void StartFrontEnd()
    {
        Console.WriteLine("------------------------------- Welcome -------------------------------");
        Console.WriteLine();
        Console.WriteLine("1. Sign In");
        Console.WriteLine("2. Sign Up");
        Console.WriteLine();
        Console.Write("Choose: ");
        var chooseSign = int.Parse(Console.ReadLine());

        if (chooseSign == 1)
        {
            SignIn();
        }
        else if (chooseSign == 2)
        {
            SignUp();
        }

    }

    public static void SignIn()
    {

    }

    public static void SignUp()
    {
        Console.Clear();

        var signUp = new SignUp();
        var user = new User();
        ISignUpService signUpService = new SignUpService(); 

        Console.WriteLine("------------------------------- Sign Up -------------------------------");
        Console.WriteLine();
        
        Console.Write("User Name: ");
        user.UserName = Console.ReadLine();
        Console.Write("Email: ");
        user.Email = Console.ReadLine();        
        Console.Write("Password: ");
        user.Password = Console.ReadLine();
        Console.Write("Phone Number: ");
        user.PhoneNumber = Console.ReadLine();

        var hasUser = signUpService.RegisteredAddStudent(user);

        if (hasUser is null)
        {
            Console.WriteLine("Bunday foydalanuchi mavjud");
            Console.WriteLine("Dasturni qayta ishga tushurish uchun Enterni bosing: ");
            Console.ReadKey();
            return;
        }

        ChatRoom();
    }

    public static void ChatRoom()
    {
        Console.Clear();
        Console.WriteLine("------------------------------- Group Chat -------------------------------");
        Console.WriteLine("Welcome to the group chat! 😊");
        Console.WriteLine();

        var messages = new List<string>();

        while (true)
        {
            // Ekranni tozalaymiz, lekin yozish joyini saqlaymiz
            Console.SetCursorPosition(0, 3);

            // Barcha yozilgan xabarlarni pastga chiqaramiz
            foreach (var msg in messages)
            {
                Console.WriteLine(msg);
            }

            // Yangi xabarni kiritish
            Console.Write("> ");
            var message = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(message))
            {
                messages.Add($"You: {message}"); // Yangi xabarni ro'yxatga qo'shamiz
            }
        }
    }

}
