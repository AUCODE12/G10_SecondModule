using ConsoleApp1.Models;
using System.Text.Json;

namespace ConsoleApp1.Services;

public class TeacherServices
{
    private string teacherFilePath;

    public TeacherServices()
    {
        teacherFilePath = "../../../Data/Teachers.json";
        if (File.Exists(teacherFilePath) is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }
    }

    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();
        var teachers = GetTeachers();
        teachers.Add(teacher);
        SaveDate(teachers);

        return teacher;
    }

    public Teacher GetByIdTeacher(Guid teacherId)
    {
        var teachers = GetTeachers();
        foreach (var teacher in teachers)
        {
            if (teacher.Id == teacherId)
            {
                return teacher;
            }
        }

        return null;
    }

    public bool DeleteTeacher(Guid teacherId)
    {
        var teachers = GetTeachers();
        var teacherFromDb = GetByIdTeacher(teacherId);
        if (teacherFromDb is null)
        {
            return false;
        }
        teachers.Remove(teacherFromDb);

        return true;
    }

    public bool UpdateTeacher(Teacher newTeacher)
    {
        var teachers = GetTeachers();
        var teacherFromDb = GetByIdTeacher(newTeacher.Id);
        if (teacherFromDb is null)
        {
            return false;
        }
        var index = teachers.IndexOf(newTeacher);
        teachers[index] = newTeacher;

        return true;
    }

    public List<Teacher> GetAllTeachers()
    {
        return GetTeachers();
    }

    private void SaveDate(List<Teacher> teachers)
    {
        var teachersJson = JsonSerializer.Serialize(teachers);
        File.WriteAllText(teacherFilePath, teachersJson);
    }

    private List<Teacher> GetTeachers()
    {
        var teachersJson = File.ReadAllText(teacherFilePath);
        var teachers = JsonSerializer.Deserialize<List<Teacher>>(teachersJson);

        return teachers;
    }
}
