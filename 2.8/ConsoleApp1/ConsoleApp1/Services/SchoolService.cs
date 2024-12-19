using ConsoleApp1.DataAccess.Entities;
using ConsoleApp1.Repositories;
using ConsoleApp1.Services.DTOs;
using System.Text.RegularExpressions;

namespace ConsoleApp1.Services;

public class SchoolService : ISchoolService
{
    private readonly ISchoolRepository _schoolRepository;

    public SchoolService()
    {
        _schoolRepository = new SchoolRepository();
    }

    public Guid AddSchool(SchoolCreateDto schoolCreateDto)
    {
        if (!IsValidEmail(schoolCreateDto.Email))
        {
            throw new Exception("Qo'shishda xatolik");
        }
        var entity = ConvertToEntity(schoolCreateDto);
        var id = _schoolRepository.WriteSchool(entity);

        return id;
    }

    public void DeleteSchool(Guid schoolId)
    {
        _schoolRepository.DeleteSchool(schoolId);
    }

    public SchoolGetDto GetMostSchoolInSchool()
    {
        var schoolMostStudent = _schoolRepository.ReadMostSchoolInSchool();
        var schoolDtoMostStudent = ConvertToDto(schoolMostStudent);
        return schoolDtoMostStudent;
    }

    public SchoolGetDto GetSchoolById(Guid schoolId)
    {
        var school = _schoolRepository.ReadSchoolById(schoolId);
        var schoolDto = ConvertToDto(school);
        return schoolDto;
    }

    public List<SchoolGetDto> GetSchools()
    {
        var schools = _schoolRepository.ReadSchools();
        var schoolsDto = new List<SchoolGetDto>();
        foreach (var school in schools)
        {
            schoolsDto.Add(ConvertToDto(school));
        }

        return schoolsDto;
    }

    public void UpdateSchool(SchoolUpdateDto schoolUpdateDto)
    {
        _schoolRepository.UpdateSchool(ConvertToEntity(schoolUpdateDto));
    }

    private School ConvertToEntity(SchoolCreateDto schoolCreateDto)
    {
        return new School
        {
            Id = Guid.NewGuid(),
            Name = schoolCreateDto.Name,
            Address = schoolCreateDto.Address,
            City = schoolCreateDto.City,
            State = schoolCreateDto.State,
            Country = schoolCreateDto.Country,
            Phone = schoolCreateDto.Phone,
            Email = schoolCreateDto.Email,
            StudentCount = schoolCreateDto.StudentCount,
            ZipCode = schoolCreateDto.ZipCode,
        };
    }

    private School ConvertToEntity(SchoolUpdateDto schoolUpdateDto)
    {
        return new School
        {
            Id = schoolUpdateDto.Id,
            Name = schoolUpdateDto.Name,
            Address = schoolUpdateDto.Address,
            City = schoolUpdateDto.City,
            State = schoolUpdateDto.State,
            Country = schoolUpdateDto.Country,
            Phone = schoolUpdateDto.Phone,
            Email = schoolUpdateDto.Email,
            StudentCount = schoolUpdateDto.StudentCount,
            ZipCode = schoolUpdateDto.ZipCode,
        };
    }

    private SchoolGetDto ConvertToDto(School school)
    {
        return new SchoolGetDto
        {
            Id = school.Id,
            Name = school.Name,
            City = school.City,
            State = school.State,
            Country = school.Country,
            Phone = school.Phone,
            Email = school.Email,
            StudentCount = school.StudentCount,
            Address = school.Address,
        };
    }

    private bool IsValidEmail(string email)
    {
        if (!_schoolRepository.EmailContains(email) || string.IsNullOrWhiteSpace(email))
        {
            return false;
        }
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }
}
