using E_Wallet.Api.Services.DTOs;

namespace E_Wallet.Api.Services;

public interface IPlasticCardService
{
    Guid AddPlasticCard(PlasticCardCreateDto plasticCardCreateDto);

    void DeletePlasticCard(Guid plasticCardId);

    void UpdatePlasticCard(PlasticCardUpdateDto plasticCardUpdateDto);

    List<PlasticCardGetDto> GetAllPlasticCards();

    List<PlasticCardGetDto> GetPlasticCardByBankName(string bankName);

    PlasticCardGetDto GetPlasticCardById(Guid plasticCardId);
}