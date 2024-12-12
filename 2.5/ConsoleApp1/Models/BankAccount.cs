namespace ConsoleApp1.Models;

public class BankAccount
{
	private int _accountNumber;

	public int AccountNumber
    {
		get { return _accountNumber; }
		set { _accountNumber = value; }
	}

    private double _balance = 0;

    public double Balance
    {
        get { return _balance; }
    }

    public void Deposit(double amount)
    {
        _balance += amount;
    }
}
