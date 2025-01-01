using E_tijorat.Api.DataAccess.Entities;

namespace E_tijorat.Api.Repositories;

public interface ISignInRepository
{
    Guid WriteSignIp(ETijoratSignIn signUp);

    void RemoveSignIp(Guid id);
}