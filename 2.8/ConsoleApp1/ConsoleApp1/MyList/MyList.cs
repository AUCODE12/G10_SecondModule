namespace ConsoleApp1.MyList.MyList;

public class MyList : IMyList
{
    private int[] items;
    private int count;

    public MyList()
    {
        items = new int[4];
        count = 0;
    }
    private void Resize()
    {
        var newItems = new int[items.Length * 2];
        for (var i = 0; i < items.Length; i++)
        {
            newItems[i] = items[i];
        }
        items = newItems;
    }

    private void CheckIndex(int index)
    {
        if (0 > index || count <= index)
        {
            throw new IndexOutOfRangeException();
        }
    }

    public void AddItem(int item)
    {
        if (count == items.Length)
        {
            Resize();
        }
        items[count++] = item;
    }

    public int GetItemAt(int index)
    {
        CheckIndex(index);
        return items[index];
    }

    public void RemoveItemAt(int index)
    {
        CheckIndex(index);
        for (var i = 0; i < items.Length - 1; i++)
        {
            items[i] = items[i + 1];
        }

        var removeItems = new int[items.Length - 1];
        for (var i = 0; i < removeItems.Length; i++)
        {
            removeItems[i] = items[i];
        }

        items = removeItems;
    }

    public void AddItemsRange(int[] nums)
    {

    }

    public void ReplaceAllItems(int oldElement, int newElement)
    {

    }

    public int GetItemIndex(int item)
    {

    }
}
