using ConsoleApp1.DataAccess.Entities;

namespace ConsoleApp1.Repositories;

public interface IStudentRepository
{
    Student WriteStudent(Student student);

    List<Student> ReadStudents();

    bool UpdateStudent(Student updateStudent);

    bool RemoveStudent(Guid id);

    Student ReadStudentById(Guid id);

    bool CheckEmailContains(string email);
}