
using E_tijorat.Api.DataAccess.Entities;

namespace E_tijorat.Api.Repositories;

public class UserPanelRepository : IUserPanelRepository
{
    private readonly IAdmistratorPanelRepository _adminstratorRepository;
    private readonly string _path;
    private List<ProductInCard> _productsInCard;

    public UserPanelRepository()
    {
        _adminstratorRepository = new AdmistratorPanelRepository();
        _path = "../../../DataAccess/Data/ProductsInCard.json";
        if(!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _productsInCard = new List<ProductInCard>();
    }
    public Guid AdditionProductCart(Guid productId)
    {
        var product = _adminstratorRepository.ReadProductById(productId);
        var user = _adminstratorRepository.
    }

    public void SubtractionProductCard(Guid productId)
    {
        throw new NotImplementedException();
    }
}
