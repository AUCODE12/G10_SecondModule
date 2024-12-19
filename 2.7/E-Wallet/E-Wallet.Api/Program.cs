using E_Wallet.Api.Services;
using E_Wallet.Api.Services.DTOs;

namespace E_Wallet.Api;

internal class Program
{
    static void Main(string[] args)
    {
        // Elektron to‘lov tizimi (E-Wallet Management)

        var dto1 = new PlasticCardCreateDto()
        {
            BankName = "Ipak Yo'li Bank",
            CardHolderName = "Ahmadjon",
            ExpirationDate = "11/29",
            CardNumber = "4023060504084210",
            Password = "0212",
        };

        var dto2 = new PlasticCardUpdateDto()
        {
            Id = new Guid("18fe61af-64b5-4868-ab4a-7e1d216d51ba"),
            BankName = "UzCard",
            CardHolderName = "Ahmadjon",
            ExpirationDate = "11/29",
            CardNumber = "5614682123928337",
            Password = "0212",
        };

        IPlasticCardService plasticCardService = new PlasticCardService();

        //plasticCardService.AddPlasticCard(dto1);
        plasticCardService.UpdatePlasticCard(dto2);

        var cards = plasticCardService.GetAllPlasticCards();
        foreach (var card in cards)
        {
            Console.WriteLine(card.CardNumber);
            Console.WriteLine(card.CardHolderName);
        }
    }
}
