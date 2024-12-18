using E_Wallet.Api.DataAccess.Entities;
using System.Data;
using System.Text.Json;

namespace E_Wallet.Api.Repositories;

public class PlasticCardRepository : IPlasticCardRepository
{
    private readonly string _path;
    private List<PlasticCard> _cards;

    public PlasticCardRepository()
    {
        _path = "../../../DataAccess/Data/PlasticCards.json";
        _cards = new List<PlasticCard>();
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _cards = ReadAllPlasticCards();
    }

    public void CardContains(string cardNumber)
    {
        foreach (var card in _cards)
        {
            if (card.CardNumber == cardNumber)
            {
                throw new Exception("Bunday plastic card mavjud");
            }
        }
    }

    public List<PlasticCard> ReadAllPlasticCards()
    {
        var readFileJson = File.ReadAllText(_path);
        var writeList = JsonSerializer.Deserialize<List<PlasticCard>>(readFileJson);

        return writeList;
    }

    public List<PlasticCard> ReadPlasticCardByBankName(string bankName)
    {
        var cardsByBankName = new List<PlasticCard>();
        foreach (var card in _cards)
        {
            if (card.BankName == bankName)
            {
                if (card.BankName == bankName)
                {
                    cardsByBankName.Add(card);
                }
            }
        }

        return cardsByBankName;
    }

    public PlasticCard ReadPlasticCardById(Guid plasticCardId)
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
        _cards.Remove(card);
        SavaData();
    }

    public void UpdatePlasticCard(PlasticCard updatePlacticCard)
    {
        var card = ReadPlasticCardById(updatePlacticCard.Id);
        var index = _cards.IndexOf(card);
        _cards[index] = updatePlacticCard;
        SavaData();
    }

    public Guid WritePlasticCard(PlasticCard plasticCard)
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
