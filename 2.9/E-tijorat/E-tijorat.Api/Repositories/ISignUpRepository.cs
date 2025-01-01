using E_tijorat.Api.DataAccess.Entities;

namespace E_tijorat.Api.Repositories;

public interface ISignUpRepository
{
    Guid WriteSignUp(ETijoratSignUp signUp);
}