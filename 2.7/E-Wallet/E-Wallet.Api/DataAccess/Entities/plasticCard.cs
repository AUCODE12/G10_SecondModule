namespace E_Wallet.Api.DataAccess.Entities;

public class PlasticCard
{
    public Guid Id { get; set; }

    public string CardNumber { get; set; } 

    public string ExpirationDate { get; set; }

    public string BankName { get; set; }

    public string CardHolderName { get; set; } 

    public string Password { get; set; }
    
    public decimal Balance { get; set; } 
}
