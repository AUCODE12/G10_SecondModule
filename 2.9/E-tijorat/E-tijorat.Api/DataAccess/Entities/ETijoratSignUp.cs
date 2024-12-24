using E_tijorat.Api.DataAccess.Enums;

namespace E_tijorat.Api.DataAccess.Entities;

public class ETijoratSignUp
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    public bool IsMerried { get; set; }

    public Gender GenderSelect { get; set; }
}
