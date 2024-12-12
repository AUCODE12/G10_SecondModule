namespace ConsoleApp1.Models;

public class Vehicle
{
    protected double _speed { get; set; }

	protected double _fuel;

	protected double Fuel
    {
		get { return _fuel; }
		set
		{
			if (50  > value + _fuel)
			{
                _fuel += value;
			}
		}
	}

}
