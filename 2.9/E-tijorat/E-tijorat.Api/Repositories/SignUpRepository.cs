using E_tijorat.Api.DataAccess.Entities;
using System.Text.Json;

namespace E_tijorat.Api.Repositories;

public class SignUpRepository : ISignUpRepository

{
    private readonly string _signUpPath;
    private readonly List<ETijoratSignUp> _eTijoratSignUps;

    public SignUpRepository()
    {
        _signUpPath = "../../../DataAccess/Data/SignUpUsers.json";
        if (!File.Exists(_signUpPath))
        {
            File.WriteAllText(_signUpPath, "[]");
        }

        _eTijoratSignUps = ReadAllSignUpUser();
    }

    public Guid WriteSignUp(ETijoratSignUp signUp)
    {
        _eTijoratSignUps.Add(signUp);
        SaveData();
        return signUp.Id;
    }

    private void SaveData()
    {
        var signUpJson = JsonSerializer.Serialize(_eTijoratSignUps);
        File.WriteAllText(signUpJson, signUpJson);
    }

    private List<ETijoratSignUp> ReadAllSignUpUser()
    {
        var signUpJson = File.ReadAllText(_signUpPath);
        var signUpList = JsonSerializer.Deserialize<List<ETijoratSignUp>>(signUpJson); 
        return signUpList;
    }
}
