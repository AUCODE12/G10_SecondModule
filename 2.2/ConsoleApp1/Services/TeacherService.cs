using ConsoleApp1.Models;
using System.Text.Json;

namespace ConsoleApp1.Services;

public class TeacherService
{
    private string teacherFilePath;

    public TeacherService()
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

        foreach (var teacher in teachers)
        {
            if(teacher.Id == teacherId)
            {
                teachers.Remove(teacher);
                break;
            }
        }
        SaveDate(teachers);

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

        for (var i = 0; i < teachers.Count; i++)
        {
            if (teachers[i].Id == newTeacher.Id)
            {
                teachers[i] = newTeacher;
                break;
            }
        }

        SaveDate(teachers);
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
