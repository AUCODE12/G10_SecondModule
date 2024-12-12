namespace ConsoleApp1.Models;

public class Car : Vehicle
{
    public void Refuel(double amount)
    {
        if (amount > 0)
        {
            Fuel += amount;
        }
        else
        {
            Fuel -= amount;
        }
    }

    public double Drive(double distance)
    {
        return distance / Speed;
    }
}
