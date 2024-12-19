using ConsoleApp1.DataAccess.Entities;

namespace ConsoleApp1.Repositories;

public interface ISchoolRepository
{
    Guid WriteSchool(School school);

    List<School> ReadSchools();

    School ReadSchoolById(Guid id);

    School ReadMostSchoolInSchool();

    void UpdateSchool(School updateSchool);

    void DeleteSchool(Guid id);

    bool EmailContains(string email);
}