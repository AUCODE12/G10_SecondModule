using E_Wallet.Api.DataAccess.Entities;
using E_Wallet.Api.Repositories;
using E_Wallet.Api.Services.DTOs;

namespace E_Wallet.Api.Services;

public class PlasticCardService : IPlasticCardService
{
    private readonly IPlasticCardRepository _plasticCardRepository;

    public PlasticCardService()
    {
        _plasticCardRepository = new PlasticCardRepository();
    }

    public Guid AddPlasticCard(PlasticCardCreateDto plasticCardCreateDto)
    {
        var check = ValidatePlasticCreateDto(plasticCardCreateDto);
        if (check is false)
        {
            throw new Exception("Qo'shishda xatolik");
        }
        var entity = ConvertToEntity(plasticCardCreateDto);
        var id = _plasticCardRepository.WritePlasticCard(entity);

        return id;   
    }

    public void DeletePlasticCard(Guid plasticCardId)
    {
        _plasticCardRepository.RemovePlasticCard(plasticCardId);
    }

    public List<PlasticCardGetDto> GetAllPlasticCards()
    {
        var plasticCards = _plasticCardRepository.ReadAllPlasticCards();
        var plasticCardsDto = new List<PlasticCardGetDto>();
        foreach (var plasticCard in plasticCards)
        {
            plasticCardsDto.Add(ConvertToDto(plasticCard));
        }

        return plasticCardsDto;
    }

    public List<PlasticCardGetDto> GetPlasticCardByBankName(string bankName)
    {
        var plasticCards = _plasticCardRepository.ReadPlasticCardByBankName(bankName);
        var plasticCardsDtoByBankName = new List<PlasticCardGetDto>();
        foreach (var plasticCard in plasticCards)
        {
            plasticCardsDtoByBankName.Add(ConvertToDto(plasticCard));
        }

        return plasticCardsDtoByBankName;
    }

    public PlasticCardGetDto GetPlasticCardById(Guid plasticCardId)
    {
        var plasticCards = _plasticCardRepository.ReadPlasticCardById(plasticCardId);
        var plasticCardsDtoById = ConvertToDto(plasticCards);
        return plasticCardsDtoById;
    }

    public void UpdatePlasticCard(PlasticCardUpdateDto plasticCardUpdateDto)
    {
        var entity = ConvertToEntity(plasticCardUpdateDto);
        _plasticCardRepository.UpdatePlasticCard(entity);
    }

    private PlasticCard ConvertToEntity(PlasticCardCreateDto plasticCardCreateDto)
    {
        return new PlasticCard
        {
            Id = Guid.NewGuid(),
            CardNumber = plasticCardCreateDto.CardNumber,
            ExpirationDate = plasticCardCreateDto.ExpirationDate,
            BankName = plasticCardCreateDto.BankName,
            CardHolderName = plasticCardCreateDto.CardHolderName,
            Password = plasticCardCreateDto.Password,
        };
    }

    private PlasticCard ConvertToEntity(PlasticCardUpdateDto plasticCardUpdateDto)
    {
        return new PlasticCard
        {
            Id = plasticCardUpdateDto.Id,
            ExpirationDate = plasticCardUpdateDto.ExpirationDate,
            BankName = plasticCardUpdateDto.BankName,
            CardHolderName = plasticCardUpdateDto.CardHolderName,
            Password = plasticCardUpdateDto.Password,
        };
    }

    private PlasticCardGetDto ConvertToDto(PlasticCard plasticCard)
    {
        return new PlasticCardGetDto
        {
            Id = plasticCard.Id,
            Balance = plasticCard.Balance,
            CardNumber = plasticCard.CardNumber,
            CardHolderName = plasticCard.CardHolderName,
            BankName = plasticCard.BankName,
        };
    }

    private bool ValidatePlasticCreateDto(PlasticCardCreateDto objDto)
    {
        _plasticCardRepository.CardContains(objDto.CardNumber);

        long convetInt;

        if (objDto.CardNumber.Length != 16 || !long.TryParse(objDto.CardNumber, out convetInt))
        {
            return false;
        }
        if (objDto.Password.Length != 4)
        {
            return false;
        }

        return true;
    }
}
