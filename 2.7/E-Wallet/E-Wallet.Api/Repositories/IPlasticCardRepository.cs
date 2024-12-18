using E_Wallet.Api.DataAccess.Entities;

namespace E_Wallet.Api.Repositories;

public interface IPlasticCardRepository
{
    Guid WritePlasticCard(PlasticCard plasticCard);

    void RemovePlasticCard(Guid plasticCardId);

    void UpdatePlasticCard(PlasticCard updatePlacticCard);

    void CardContains(string cardNumber);

    List<PlasticCard> ReadAllPlasticCards();

    List<PlasticCard> ReadPlasticCardByBankName(string bankName);
    
    PlasticCard ReadPlasticCardById(Guid plasticCardId);
}