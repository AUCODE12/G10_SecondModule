using System.Linq;

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
            if (_items[i].Equals(item))
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
            if (_items[i].Equals(oldNum))
            {
                _items[i] = newNum;
            }
        }
    }

    //list ichida element bor yoki yo'qligini tekshiradi
    public bool Contains(T item)
    {
        if (GetItemIndex(item) == -1)
        {
            return false;
        }

        return true;
    }

    // Listni tozalash
    public void Clear()
    {
        for (var i = 0; i < _items.Length; i++)
        {
            RemoveItemAt(i);
        }
    }

    // list to arr
    public T[] ToArray()
    {
        if (_items.Count() == _count)
        {
            return _items;
        }

        var arr = new T[_items.Length];
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = _items[i];
        }

        return arr;
    }

    // kelayotgan itemning oxirgisini indexsini qaytaradi
    public int GetLastIndex(T item)
    {
        for (var i = _count - 1; i >= 0; i--)
        {
            if (_items[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    // Sort
    public void Sort()
    {
          
    }

    // boshlanish nuqtadan malum bir masofagacha olish
    public T[] GetRange(int startIndex, int count)
    {
        var newArr = new T[count];
        for (var i = 0; i < count; i++)
        {
            newArr[i] = _items[startIndex];
            startIndex++;
        }

        return newArr;
    }
    
    // Malum indexdagi itemni, boshqa itemga o'zgartiradi
    public void InsertAt(int index, T item)
    {
        _items[index] = item;
    }

    // listini tekarisiga o'giradi
    public void Reverse()
    {
        var newItems = new T[_items.Length];
        for (var i = _items.Length - 1; i >= 0; i--)
        {
            newItems[_items.Length - 1 - i] = _items[i];
        }

        _items = newItems;
    }

    // Private
    //List to'lganda listni uzunligini 2 barobarga oshiradi
    private void Resize()
    {
        var _newItems = new T[_items.Length * 2];
        for (var i = 0; i < _items.Length; i++)
        {
            _newItems[i] = _items[i];
        }

        _items = _newItems;
    }

    //kelayotgan index lista bormi yo'qmi tekshiradi
    private void CheckIndex(int index)
    {
        if (0 > index || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }
    }
}
