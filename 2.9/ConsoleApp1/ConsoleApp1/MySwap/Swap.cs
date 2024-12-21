namespace ConsoleApp1.MySwap;

public class Swap
{
    public void MySwap<T>(ref T a, ref T b)
    {
        T aSave = a;
        a = b;
        b = aSave;
    }
}
