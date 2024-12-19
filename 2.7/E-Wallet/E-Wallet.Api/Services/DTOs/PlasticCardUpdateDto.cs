namespace E_Wallet.Api.Services.DTOs;

public class PlasticCardUpdateDto : PlasticCardBaseDto
{
    public Guid Id { get; set; }

    public string ExpirationDate { get; set; }

    public string CardNumber { get; set; }

    public string Password { get; set; }
}
