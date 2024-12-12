namespace ConsoleApp1.Models;

public class Car : Vehicle
{
    public void Refuel(double amount)
    {
        _fuel += amount;
    }

    public void Drive(double distance)
    {
        Console.WriteLine(distance / _speed);
    }
}
