using ConsoleApp1.Models;

namespace ConsoleApp1.Services;

public interface ITeacherService
{
    public Teacher AddTeacher(Teacher teacher);


    public Teacher GetById(Guid teacherId);


    public bool DeleteTeacher(Guid teacherId);


    public bool UpdateTeacher(Teacher teaacher);


    public List<Teacher> GetAllTeachers();
}