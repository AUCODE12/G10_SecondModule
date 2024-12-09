using _2._2dars.Api.Models;
using _2._2dars.Api.Services;

namespace _2._2dars.Api;

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
            else if (userName == student1UserName && password == student1Password)
            {
                RunStudent();
            }
            else if (userName == student2UserName && password == student2Password)
            {
                RunStudent();
            }
        }
    }

    public static void RunTeacher()
    {
        var studentService = new StudentService();
        var testService = new TestService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Test");
            Console.WriteLine("2. Student");
            Console.WriteLine();
            Console.Write("Enter: ");
            var firstOption = Console.ReadLine();

            if (firstOption == "0")
            {
                return;
            }
            else if (firstOption == "1")
            {
                while (true)
                {
                    Console.Clear();
                    Console.Clear();
                    Console.WriteLine("0. Quit");
                    Console.WriteLine("1. Add test");
                    Console.WriteLine("2. Delete test");
                    Console.WriteLine("3. Read tests");
                    Console.WriteLine("4. Get by id");
                    Console.WriteLine("5. Update test");
                    Console.WriteLine("6. Get random tests");
                    Console.Write("enter : ");
                    var secondOption = Console.ReadLine();

                    if (secondOption == "0")
                    {
                        return;
                    }
                    else if (secondOption == "1")
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
                    else if (secondOption == "2")
                    {
                        Console.Write("Enter id :");
                        var id = Guid.Parse(Console.ReadLine());
                        testService.DeleteTest(id);
                    }
                    else if (secondOption == "3")
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
                    else if (secondOption == "4")
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
                    else if (secondOption == "5")
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
                    else if (secondOption == "6")
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
            else if (firstOption == "2")
            {
                while (true)
                {
                    Console.Clear();
                    Console.Clear();
                    Console.WriteLine("0. Quit");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Delete Student");
                    Console.WriteLine("3. Read Students");
                    Console.WriteLine("4. Get by id Student");
                    Console.WriteLine("5. Update Student");
                    Console.Write("enter : ");
                    var thirdOption = Console.ReadLine();

                    if (thirdOption == "0")
                    {
                        return;
                    }
                    else if (thirdOption == "1")
                    {
                        var student = new Student();
                        Console.Write("First Name :");
                        student.FirstName = Console.ReadLine();

                        Console.Write("Last name :");
                        student.LastName = Console.ReadLine();

                        Console.Write("Age :");
                        student.Age = int.Parse(Console.ReadLine());

                        Console.Write("Degree :");
                        student.Degree = Console.ReadLine();

                        Console.Write("Gender :");
                        student.Gender = Console.ReadLine();

                        studentService.AddStudent(student);
                    }
                    else if (thirdOption == "2")
                    {
                        Console.Write("Enter id :");
                        var id = Guid.Parse(Console.ReadLine());
                        studentService.DeleteStudent(id);
                    }
                    else if (thirdOption == "3")
                    {
                        var students = studentService.GetAllStudents();
                        foreach (var student in students)
                        {
                            Console.WriteLine($"id : {student.Id}");
                            Console.WriteLine($"First Name : {student.FirstName}");
                            Console.WriteLine($"Last Name : {student.LastName}");
                            Console.WriteLine($"Age : {student.Age}");
                            Console.WriteLine($"Degree : {student.Degree}");
                            Console.WriteLine($"Gender : {student.Gender}");
                            Console.WriteLine($"Results : {student.Results}");
                            Console.WriteLine();
                        }
                    }
                    else if (thirdOption == "4")
                    {
                        Console.Write("Enter id :");
                        var id = Guid.Parse(Console.ReadLine());
                        var student = studentService.GetById(id);
                        Console.WriteLine($"id : {student.Id}");
                        Console.WriteLine($"First Name : {student.FirstName}");
                        Console.WriteLine($"Last Name : {student.LastName}");
                        Console.WriteLine($"Age : {student.Age}");
                        Console.WriteLine($"Degree : {student.Degree}");
                        Console.WriteLine($"Gender : {student.Gender}");
                        Console.WriteLine($"Results : {student.Results}");
                        Console.WriteLine();
                    }
                    else if (thirdOption == "5")
                    {
                        var newStudent = new Student();

                        Console.Write("Id :");
                        newStudent.Id = Guid.Parse(Console.ReadLine());

                        Console.Write("First Name :");
                        newStudent.FirstName = Console.ReadLine();

                        Console.Write("Last name :");
                        newStudent.LastName = Console.ReadLine();

                        Console.Write("Age :");
                        newStudent.Age = int.Parse(Console.ReadLine());

                        Console.Write("Degree :");
                        newStudent.Degree = Console.ReadLine();

                        Console.Write("Gender :");
                        newStudent.Gender = Console.ReadLine();

                        studentService.UpdateStudent(newStudent);
                    }

                    Console.ReadKey();
                }
            }
        }

        Console.ReadKey();
    }

    public static void RunDirector()
    {
        var teacherService = new TeacherService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. Delete Teacher");
            Console.WriteLine("3. Read Teacher");
            Console.WriteLine("4. Get by id Teacher");
            Console.WriteLine("5. Update Teacher");
            Console.Write("enter : ");
            var option = Console.ReadLine();

            if (option == "0")
            {
                return;
            }
            else if (option == "1")
            {
                var teacher = new Teacher();
                Console.Write("First Name :");
                teacher.FirstName = Console.ReadLine();

                Console.Write("Last Name :");
                teacher.LastName = Console.ReadLine();

                Console.Write("Age :");
                teacher.Age = int.Parse(Console.ReadLine());

                Console.Write("Subject :");
                teacher.Subject = Console.ReadLine();

                Console.Write("Gender :");
                teacher.Gender = Console.ReadLine();

                teacherService.AddTeacher(teacher);
            }
            else if (option == "2")
            {
                Console.Write("Enter id :");
                var id = Guid.Parse(Console.ReadLine());
                teacherService.DeleteTeacher(id);
            }
            else if (option == "3")
            {
                var teachers = teacherService.GetAllTeachers();
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"id : {teacher.Id}");
                    Console.WriteLine($"First Name : {teacher.FirstName}");
                    Console.WriteLine($"Last Name : {teacher.LastName}");
                    Console.WriteLine($"Age : {teacher.Age}");
                    Console.WriteLine($"Subject : {teacher.Subject}");
                    Console.WriteLine($"Gender : {teacher.Gender}");
                    Console.WriteLine($"Like : {teacher.Likes}");
                    Console.WriteLine($"Dislike : {teacher.DisLikes}");
                    Console.WriteLine();
                }
            }
            else if (option == "4")
            {
                Console.Write("Enter id :");
                var id = Guid.Parse(Console.ReadLine());
                var teacher = teacherService.GetById(id);
                Console.WriteLine($"id : {teacher.Id}");
                Console.WriteLine($"First Name : {teacher.FirstName}");
                Console.WriteLine($"Last Name : {teacher.LastName}");
                Console.WriteLine($"Age : {teacher.Age}");
                Console.WriteLine($"Subject : {teacher.Subject}");
                Console.WriteLine($"Gender : {teacher.Gender}");
                Console.WriteLine($"Like : {teacher.Likes}");
                Console.WriteLine($"Dislike : {teacher.DisLikes}");
                Console.WriteLine();
            }
            else if (option == "5")
            {
                var newteacher = new Teacher();

                Console.Write("Id :");
                newteacher.Id = Guid.Parse(Console.ReadLine());

                Console.Write("First Name :");
                newteacher.FirstName = Console.ReadLine();

                Console.Write("Last Name :");
                newteacher.LastName = Console.ReadLine();

                Console.Write("Age :");
                newteacher.Age = int.Parse(Console.ReadLine());

                Console.Write("Subject :");
                newteacher.Subject = Console.ReadLine();

                Console.Write("Gender :");
                newteacher.Gender = Console.ReadLine();

                teacherService.UpdateTeacher(newteacher);
            }

            Console.ReadKey();
        }
    }

    public static void RunStudent()
    {
        var testService = new TestService();
        var studentService = new StudentService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Test ishlash");
            Console.WriteLine("2. Test tarixini ko'rish");
            Console.WriteLine();
            Console.Write("Enter: ");
            var fourthOption = Console.ReadLine();

            if (fourthOption == "0")
            {
                return;
            }
            else if (fourthOption == "1")
            {
                Console.Clear();
                Console.Write("Nechta test ishlaysiz: ");
                var testAmount = int.Parse(Console.ReadLine());

                var requestTests = testService.GetRandomTests(testAmount);
                var count = 1;
                var resultCount = testAmount;
                var testModels = new Test();
                foreach (var test in requestTests)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{count}: {test.QuestionText}");
                    Console.Write($"A) {test.AVariant}      B) {test.BVariant}      C) {test.CVariant}\n");
                    Console.Write("Answer (A/B/C): ");
                    var answerOption = Console.ReadLine();
                    if (!(answerOption == testModels.Answer))
                    {
                        resultCount--;
                    }
                    count++;
                }
                var studentModels = new Student();
                studentModels.Results.Add(resultCount);
            }
            else if (fourthOption == "2")
            {
                Console.Clear();
                Console.WriteLine("                      Result");
                Console.WriteLine();
                var student = new Student();
                var count = 1;
                foreach (var result in student.Results)
                {
                    Console.Write($"{count}) {result};  ");
                    count++;
                }

            }
        }
    }
}