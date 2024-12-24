namespace E_tijorat.Api.Repositories;

public interface IUserPanelRepository
{
    Guid AdditionProductCart(Guid productId);

    void SubtractionProductCard(Guid productId);
}