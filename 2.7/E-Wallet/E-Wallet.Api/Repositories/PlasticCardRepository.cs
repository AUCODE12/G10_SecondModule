using E_Wallet.Api.DataAccess.Entities;
using System.Data;
using System.Text.Json;

namespace E_Wallet.Api.Repositories;

public class PlasticCardRepository : IPlasticCardRepository
{
    private readonly string _path;
    private List<plasticCard> _cards;

    public PlasticCardRepository()
    {
        _path = "../../../DataAccess/Data/PlasticCards.json";
        _cards = new List<plasticCard>();
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _cards = ReadAllPlasticCards();
    }

    public void CardContains(string cardNumber)
    {
        throw new NotImplementedException();
    }

    public List<plasticCard> ReadAllPlasticCards()
    {
        throw new NotImplementedException();
    }

    public List<plasticCard> ReadPlasticCardByBankName(string bankName)
    {
        throw new NotImplementedException();
    }

    public plasticCard ReadPlasticCardById(Guid plasticCardId)
    {
        foreach (var card in _cards)
        {
            if (card.Id == plasticCardId)
            {
                return card;
            }
        }

        throw new Exception($"Bunday kartta mavjud emas: {plasticCardId}");
    }

    public void RemovePlasticCard(Guid plasticCardId)
    {
        var card = ReadPlasticCardById(plasticCardId);
        var index = _cards.IndexOf(card);
        _cards[index] = updatePlacticCard;
        SavaData();
    }

    public void UpdatePlasticCard(plasticCard updatePlacticCard)
    {
        var card = ReadPlasticCardById(updatePlacticCard.Id);
        var index = _cards.IndexOf(card);
        _cards[index] = updatePlacticCard;
        SavaData();
    }

    public Guid WritePlasticCard(plasticCard plasticCard)
    {
        _cards.Add(plasticCard);
        SavaData();
        return plasticCard.Id;
    }

    private void SavaData()
    {
        var plasticCardsJson = JsonSerializer.Serialize(_cards);
        File.WriteAllText(_path, plasticCardsJson);
    }
}
