using ConsoleApp1.DataAccess.Entities;
using System.Text.Json;

namespace ConsoleApp1.Repositories;

public class StudentRepository : IStudentRepository
{
    private string path;
    private List<Student> _students;

    public StudentRepository()
    {
        path = "../../../DataAccess/Data/Students.json";
        _students = new List<Student>();

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "[]");
        }

        _students = ReadStudents();
    }
    
    public bool CheckEmailContains(string email)
    {
        foreach (var student in _students)
        {
            if (student.Email == email)
            {
                return true;
            }
        }

        return false;
    }

    public Student ReadStudentById(Guid id)
    {
        foreach (var student in _students)
        {
            if (student.Id == id)
            {
                return student;
            }
        }
        return null;
    }

    public List<Student> ReadStudents()
    {
        var studentsJson = File.ReadAllText(path);
        var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
        return students;
    }

    public bool RemoveStudent(Guid id)
    {
        var requestHasStudent = ReadStudentById(id);
        if (requestHasStudent is null)
        {
            return false;
        }
        _students.Remove(requestHasStudent);
        SaveData();
        return true;
    }

    public bool UpdateStudent(Student updateStudent)
    {
        var requestHasStudent = ReadStudentById(updateStudent.Id);
        if (requestHasStudent is null)
        {
            return false;
        }
        var index = _students.IndexOf(updateStudent);
        _students[index] = updateStudent;
        SaveData();
        return true;
    }

    public Student WriteStudent(Student student)
    {
        _students.Add(student);
        SaveData();
        return student;
    }

    public void SaveData()
    {
        var studentsJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(path, studentsJson);
    }
}
