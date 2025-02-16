namespace ConsoleApp1;

public class ListNode
{
    public int Val;           // Tugun qiymati
    public ListNode Next;     // Keyingi tugunga ishora

    public ListNode(int val = 0, ListNode next = null)
    {
        Val = val;
        Next = next;
    }
}