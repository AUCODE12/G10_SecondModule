namespace E_Wallet.Api.Services.DTOs;

public class PlasticCardGetDto : PlasticCardBaseDto
{
    public Guid Id { get; set; }

    public decimal Balance { get; set; }
}
