namespace ConsoleApp1.MyList1;

public class FirstMyList<T> : IFirstMyList<T>
{
    private T[] _items;
    private int _count;

    public FirstMyList()
    {
        _items = new T[4];
        _count = 0;
    }

    //listga qo'shish
    public void AddItem(T item)
    {
        if (_count == _items.Length)
        {
            Resize();
        }
        _items[_count++] = item;
    }

    //listga list qo'shish
    public void AddItemsRange(T[] nums)
    {
        foreach (var item in nums)
        {
            AddItem(item);
        }
    }

    //capacityni olish length
    public int GetCapacity()
    {
        return _items.Length;
    }

    //elementlar soni olish count
    public int GetCount()
    {
        return _count;
    }

    //indexda turgan element olish
    public T GetItemAt(int index)
    {
        CheckIndex(index);
        return _items[index];
    }

    //elementni index topish
    public int GetItemIndex(T item)
    {
        for (var i = 0; i < _count; i++)
        {
            if (_items.Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    //indexdagi elementni o'chirish
    public void RemoveItemAt(int index)
    {
        for (var i = index; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        _count--;
        _items[_count - 1] = default;
    }

    //elementni boshqa element bilan almashtirish
    public void ReplaceItem(T oldNum, T newNum)
    {
        for (var i = 0; i < _count; i++)
        {
            if (_items.Equals(oldNum))
            {
                _items[i] = newNum;
            }
        }
    }



    // Private
    private void Resize()
    {
        var _newItems = new T[_items.Length * 2];
        for (var i = 0; i < _items.Length; i++)
        {
            _newItems[i] = _items[i];
        }

        _items = _newItems;
    }

    private void CheckIndex(int index)
    {
        if (0 > index || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }
    }
}
