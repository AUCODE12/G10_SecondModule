namespace E_Wallet.Api.DataAccess.Entities;

public class plasticCard
{
    public Guid Id { get; set; }

    public string CardNumber { get; set; }

    public int IssueMonth { get; set; } 

    public int IssueDay { get; set; }

    public string BankName { get; set; }

    public string CardHolderName { get; set; }

    public decimal Balance { get; set; }

    public string Password { get; set; }

    public int ExpiryYear { get; set; }
}
