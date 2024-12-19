namespace ConsoleApp1.MyList.MyList;

public interface IMyList
{
    void AddItem(int item);

    int GetItemAt(int index);

    void RemoveItemAt(int index);

    void AddItemsRange(int[] nums);

    void ReplaceAllItems(int oldElement, int newElement);

    int GetItemIndex(int item);
}