using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1;

internal class Program
{
    private static string studentUserName = "student";
    private static string studentPassword = "student";

    private static string teacherUserName = "teacher";
    private static string teacherPassword = "teacher";

    private static string directorUserName = "director";
    private static string directorPassword = "director";


    static void Main(string[] args)
    {
        /*
        //YourClass yourClass = new YourClass();
        //yourClass.Do();
        //yourClass.Do1();
        //yourClass.Do2();

        //MyClass myClass = new YourClass();

        //myClass.Do();
        //myClass.Do1();
        //myClass.Do2();


        //int number;
        //var consoleValue = Console.ReadLine();
        //int.TryParse(consoleValue, out number);

        //Console.WriteLine(number);

        //int number = int.Parse(Console.ReadLine());
        //Console.WriteLine(number);



        //var student1 = new Student()
        //{
        //    FirstName = "Ali",
        //    LastName = "Vali",
        //    Age = 20,
        //    Degree = "3",
        //    Gender = "men",
        //};

        //var student2 = new Student()
        //{
        //    FirstName = "WWW",
        //    LastName = "AAA",
        //    Age = 20,
        //    Degree = "3",
        //    Gender = "men",
        //};

        //var studentService = new StudentService();
        ////studentService.AddStudent(student1);
        ////studentService.AddStudent(student2);

        //var students = studentService.GetAllStudents();

        //Console.WriteLine(students[0].Id + " " + students[0].FirstName);
        //Console.WriteLine(students[1].Id + " " + students[1].FirstName);

        //studentService.DeleteStudent(students[1].Id);

        //var newStudents = studentService.GetAllStudents();

        //var a = 5;
        */
        
        StartFrontEnd();
    }

    public static void StartFrontEnd()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Stop");
            Console.WriteLine("1. Login");
            Console.Write("Enter : ");
            var option = Console.ReadLine();

            if (option == "0")
            {
                Console.WriteLine("thanks");
                return;
            }
            else if (option == "1")
            {
                LoginPage();
            }
        }
    }

    public static void LoginPage()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter user name :");
            var userName = Console.ReadLine();
            Console.Write("Enter password  :");
            var password = Console.ReadLine();


            if (userName == directorUserName && password == directorPassword)
            {
                RunDirector();
            }
            else if (userName == teacherUserName && password == teacherPassword)
            {
                RunTeacher();
            }
            else if (userName == studentUserName && password == studentPassword)
            {
                RunStudent();
            }

        }
    }

    public static void RunDirector()
    {
        ITeacherService teacherService = new TeacherService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. Get Teachers");
            Console.WriteLine("3. Get by id Teacher");
            Console.WriteLine("4. Update Teacher");
            Console.WriteLine("5. Delete Teacher");
            Console.WriteLine("\nBack (0)");
            Console.WriteLine();
            Console.Write("Enter option: ");
            var option = int.Parse(Console.ReadLine());

            if (option == 0)
            {
                return;
            }
            else if (option == 1)
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
            }
            else if (option == 2)
            {
                //Console.Clear();
                var teachers = teacherService.GetAllTeachers();
                var count = 1;
                Console.WriteLine("--------------- O'qituvchilar ro'yxati ---------------\n");
                foreach (var teacher in teachers)
                {
                    var teacherInfo = $"{count}) First Name: {teacher.FirstName} \nLast Name: {teacher.LastName} \nSubject: {teacher.Subject} \nAge: {teacher.Age} \nGender: {teacher.Gender}";
                    Console.WriteLine($"{teacherInfo} \n");
                    count++;
                }
            }
            else if (option == 3)
            {
                Console.Clear();
                Console.Write("Enter get Id: ");
                var id = Guid.Parse(Console.ReadLine());
                var teacher = teacherService.GetById(id);
                Console.WriteLine("\n--------------- O'qituvchi ---------------\n");
                var teacherInfo = $"First Name: {teacher.FirstName} \nLast Name: {teacher.LastName} \nSubject: {teacher.Subject} \nAge: {teacher.Age} \nGender: {teacher.Gender}";
                Console.WriteLine($"{teacherInfo}");
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
                Console.Write("Age: ");
                newTeacher.Age = int.Parse(Console.ReadLine());
                Console.Write("Subject: ");
                newTeacher.Subject = Console.ReadLine();
                Console.Write("Gender: ");
                newTeacher.Gender = Console.ReadLine();

                var request = teacherService.UpdateTeacher(newTeacher);
            }
            else if (option == 5)
            {
                Console.Clear();
                Console.WriteLine("--------------- Teacher Delete ---------------");
                Console.WriteLine();
                Console.Write("Enter Id: ");
                var deleteId = Guid.Parse(Console.ReadLine());

                teacherService.DeleteTeacher(deleteId);
            }

            Console.ReadKey();
        }
    }

    public static void RunStudent()
    {
        ITeacherService teacherService = new TeacherService();
        IStudentService studentService = new StudentService();
        ITestService testService = new TestService();
        Console.Write("Enter id :");
        Guid id;
        Guid.TryParse(Console.ReadLine(), out id);
        var student = studentService.GetById(id);

        while (true)
        {
            Console.WriteLine("1. Start test");
            Console.WriteLine("2. Like teacher");
            Console.WriteLine("3. Dislike teacher");
            Console.Write("Enter option :");
            var option = Console.ReadLine();

            if (option == "1")
            {
                Console.Clear();
                Console.Write("How many test you want to do :");
                var amount = int.Parse(Console.ReadLine());

                var tests = testService.GetRandomTests(amount);
                var correctAnswers = 0;
                foreach (var test in tests)
                {
                    Console.WriteLine(test.QuestionText);
                    Console.WriteLine($"A) {test.AVariant}");
                    Console.WriteLine($"B) {test.BVariant}");
                    Console.WriteLine($"C) {test.CVariant}");

                    Console.Write("Choose answer A/B/C : ");
                    var answer = Console.ReadLine();
                    if (test.Answer == answer)
                    {
                        correctAnswers++;
                        Console.WriteLine("Correct");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect, correct answer is : {test.Answer}");
                    }
                }

                var res = correctAnswers * 100d / tests.Count;
                student.Results.Add(res);
                studentService.UpdateStudent(student);
                Console.WriteLine($"Final answer : {res}%");
                Console.ReadKey();
            }

        }
    }

    public static void RunTeacher()
    {
        IStudentService studentService = new StudentService();
        ITestService testService = new TestService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Add test");
            Console.WriteLine("2. Delete test");
            Console.WriteLine("3. Read tests");
            Console.WriteLine("4. Get by id");
            Console.WriteLine("5. Update test");
            Console.WriteLine("6. Get random tests");
            Console.Write("enter : ");
            var option = Console.ReadLine();

            if (option == "0")
            {
                return;
            }
            else if (option == "1")
            {
                var test = new Test();
                Console.Write("Question text :");
                test.QuestionText = Console.ReadLine();

                Console.Write("A variant :");
                test.AVariant = Console.ReadLine();

                Console.Write("B variant :");
                test.BVariant = Console.ReadLine();

                Console.Write("C variant :");
                test.CVariant = Console.ReadLine();

                Console.Write("Answer A/B/C :");
                test.Answer = Console.ReadLine();

                testService.AddTest(test);
            }
            else if (option == "2")
            {
                Console.Write("Enter id :");
                var id = Guid.Parse(Console.ReadLine());
                testService.DeleteTest(id);
            }
            else if (option == "3")
            {
                var tests = testService.GetAllTests();
                foreach (var test in tests)
                {
                    Console.WriteLine($"id : {test.Id}");
                    Console.WriteLine($"Question text : {test.QuestionText}");
                    Console.WriteLine($"A variant : {test.AVariant}");
                    Console.WriteLine($"B variant : {test.BVariant}");
                    Console.WriteLine($"C variant : {test.CVariant}");
                    Console.WriteLine($"Answer : {test.Answer}");
                    Console.WriteLine();
                }
            }
            else if (option == "4")
            {
                Console.Write("Enter id :");
                var id = Guid.Parse(Console.ReadLine());
                var test = testService.GetById(id);
                Console.WriteLine($"id : {test.Id}");
                Console.WriteLine($"Question text : {test.QuestionText}");
                Console.WriteLine($"A variant : {test.AVariant}");
                Console.WriteLine($"B variant : {test.BVariant}");
                Console.WriteLine($"C variant : {test.CVariant}");
                Console.WriteLine($"Answer : {test.Answer}");
                Console.WriteLine();
            }
            else if (option == "5")
            {
                var test = new Test();

                Console.Write("Question id :");
                test.Id = Guid.Parse(Console.ReadLine());

                Console.Write("Question text :");
                test.QuestionText = Console.ReadLine();

                Console.Write("A variant :");
                test.AVariant = Console.ReadLine();

                Console.Write("B variant :");
                test.BVariant = Console.ReadLine();

                Console.Write("C variant :");
                test.CVariant = Console.ReadLine();

                Console.Write("Answer A/B/C :");
                test.Answer = Console.ReadLine();

                testService.UpdateTest(test);
            }
            else if (option == "6")
            {
                Console.Write("Enter :");
                var choice = int.Parse(Console.ReadLine());
                var tests = testService.GetRandomTests(choice);

                foreach (var test in tests)
                {
                    Console.WriteLine($"id : {test.Id}");
                    Console.WriteLine($"Question text : {test.QuestionText}");
                    Console.WriteLine($"A variant : {test.AVariant}");
                    Console.WriteLine($"B variant : {test.BVariant}");
                    Console.WriteLine($"C variant : {test.CVariant}");
                    Console.WriteLine($"Answer : {test.Answer}");
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}