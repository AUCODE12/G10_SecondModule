using ConsoleApp1.Models;
using System.Text.Json;

namespace ConsoleApp1.Services;

public class SignUpService : ISignUpService
{
    private string registeredFilePath;

    public SignUpService()
    {
        registeredFilePath = "../../../Data/registered_users.json";

        if (File.Exists(registeredFilePath) is false)
        {
            File.WriteAllText(registeredFilePath, "[]");
        }
    }

    public User RegisteredAddStudent(User user)
    {
        var users = GetUsers();
        foreach (var userCheck in users)
        {
            if (userCheck.Email == user.Email)
            {
                return null;
            }
        }
        user.Id = Guid.NewGuid();
        users.Add(user);
        SaveData(users);
        return user;
    }

    private void SaveData(List<User> users)
    {
        var usersJson = JsonSerializer.Serialize(users);
        File.WriteAllText(registeredFilePath, usersJson);
    }

    private List<User> GetUsers()
    {
        var usersJson = File.ReadAllText(registeredFilePath);
        var users = JsonSerializer.Deserialize<List<User>>(usersJson);
        return users;
    }

}
