namespace ConsoleApp1.Models;

public class Product
{
	private double _price;

	public double Price
    {
		get { return _price; }
		set { _price = value; }
	}

	private int _stock;

	public int Stock
    {
		get { return _stock; }
		set { _stock = value; }
	}

}
