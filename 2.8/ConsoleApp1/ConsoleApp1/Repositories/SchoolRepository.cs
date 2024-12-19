using ConsoleApp1.DataAccess.Entities;
using System.Text.Json;

namespace ConsoleApp1.Repositories;

public class SchoolRepository : ISchoolRepository
{
    private readonly string _path;
    private List<School> _schools;

    public SchoolRepository()
    {
        _path = "../../../DataAccess/Data/Schools.json";
        _schools = new List<School>();
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _schools = ReadSchools();
    }

    private void SaveData()
    {
        var schoolsJson = JsonSerializer.Serialize(_schools);
        File.WriteAllText(_path, schoolsJson);
    }

    public void DeleteSchool(Guid id)
    {
        var hasInDb = ReadSchoolById(id);
        _schools.Remove(hasInDb);
        SaveData();
    }

    public bool EmailContains(string email)
    {
        foreach (var school in _schools)
        {
            if (school.Email == email)
            {
                return true;
            }
        }

        return false;
    }

    public School ReadMostSchoolInSchool()
    {
        var schoolMostStudent = _schools[0];

        foreach (var school in _schools)
        {
            if (schoolMostStudent.StudentCount < school.StudentCount)
            {
                schoolMostStudent = school;
            }
        }

        return schoolMostStudent;
    }

    public School ReadSchoolById(Guid id)
    {
        foreach (var school in _schools)
        {
            if (school.Id == id)
            {
                return school;
            }
        }

        throw new Exception($"Bunday \"School\" mavjud emas: {id}");
    }

    public List<School> ReadSchools()
    {
        var schoolsJson = File.ReadAllText(_path);
        var schools = JsonSerializer.Deserialize<List<School>>(schoolsJson);
        return schools;
    }

    public void UpdateSchool(School updateSchool)
    {
        var hasInDb = ReadSchoolById(updateSchool.Id);
        var index = _schools.IndexOf(hasInDb);
        _schools[index] = updateSchool;
        SaveData();
    }

    public Guid WriteSchool(School school)
    {
        _schools.Add(school); 
        SaveData();
        return school.Id;
    }
}
