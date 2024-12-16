using ConsoleApp1.Services.DTOs;

namespace ConsoleApp1.Services;

public interface IStudentService
{
    StudentGetDto AddStudent(StudentCreateDto studentCreateDto);
    bool UpdateStudent(StudentUpdateDto studentUpdateDto);

    List<StudentGetDto> GetStudents();

    //StudentGetDto GetByIdStudent(Guid id);

    bool DeleteStudent(Guid id);

}