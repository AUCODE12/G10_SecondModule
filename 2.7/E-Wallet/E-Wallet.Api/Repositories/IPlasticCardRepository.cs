using E_Wallet.Api.DataAccess.Entities;

namespace E_Wallet.Api.Repositories;

public interface IPlasticCardRepository
{
    Guid WritePlasticCard(plasticCard plasticCard);

    void RemovePlasticCard(Guid plasticCardId);

    void UpdatePlasticCard(plasticCard updatePlacticCard);

    void CardContains(string cardNumber);

    List<plasticCard> ReadAllPlasticCards();

    List<plasticCard> ReadPlasticCardByBankName(string bankName);
    
    plasticCard ReadPlasticCardById(Guid plasticCardId);
}