namespace E_Wallet.Api.Services.DTOs;

public class PlasticCardCreateDto : PlasticCardBaseDto
{
    public string ExpirationDate { get; set; }

    public string Password { get; set; }
}
