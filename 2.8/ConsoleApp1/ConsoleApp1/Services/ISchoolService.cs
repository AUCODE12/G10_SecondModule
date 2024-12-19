using ConsoleApp1.Services.DTOs;

namespace ConsoleApp1.Services;

public interface ISchoolService
{
    Guid AddSchool(SchoolCreateDto schoolCreateDto);

    List<SchoolGetDto> GetSchools();

    SchoolGetDto GetSchoolById(Guid schoolId);

    SchoolGetDto GetMostSchoolInSchool();

    void UpdateSchool(SchoolUpdateDto schoolUpdateDto);

    void DeleteSchool(Guid schoolId);
}