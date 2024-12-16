using ConsoleApp1.DataAccess.Entities;
using ConsoleApp1.Repositories;
using ConsoleApp1.Services.DTOs;

namespace ConsoleApp1.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService()
    {
        _studentRepository = new StudentRepository();
    }

    public StudentGetDto AddStudent(StudentCreateDto studentCreateDto)
    {
        var checkingEmail = _studentRepository.CheckEmailContains(studentCreateDto.Email);
        if (!studentCreateDto.Email.EndsWith("@gmail.com") || checkingEmail)
        {
            return null;
        }

        var student = ConvetToEntityStudent(studentCreateDto);
        var studentFromDb = _studentRepository.WriteStudent(student);
        var studentDto = ConvetToDto(studentFromDb);

        return studentDto;

    }
    public bool DeleteStudent(Guid id)
    {
        var studentFromDb = _studentRepository.RemoveStudent(id);

        return studentFromDb;
    }

    public List<StudentGetDto> GetStudents()
    {
        var students = _studentRepository.ReadStudents();
        var studentGetDto = new List<StudentGetDto>();
        foreach (var student in students)
        {
            studentGetDto.Add(ConvetToDto(student));
        }

        return studentGetDto;
    }

    public bool UpdateStudent(StudentUpdateDto studentUpdateDto)
    {
        var student = ConvetToEntityStudent(studentUpdateDto);
        var requestFromDb = _studentRepository.UpdateStudent(student);

        return requestFromDb;
    }

    private Student ConvetToEntityStudent(StudentCreateDto dto)
    {
        var student = new Student()
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
            Address = dto.Address,
            ClassName = dto.ClassName,
            PhoneNumber = dto.PhoneNumber,
            Age = dto.Age
        };

        return student;
    }

    private Student ConvetToEntityStudent(StudentUpdateDto dto)
    {
        var student = new Student()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
            Address = dto.Address,
            ClassName = dto.ClassName,
            PhoneNumber = dto.PhoneNumber,
            Age = dto.Age
        };

        return student;
    }

    private StudentGetDto ConvetToDto(Student student)
    {
        var dto = new StudentGetDto()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            Address = student.Address,
            ClassName = student.ClassName,
            PhoneNumber = student.PhoneNumber,
            Age = student.Age
        };

        return dto;
    }
}
