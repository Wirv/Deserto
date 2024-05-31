using System;
using System.Collections.Generic;

public class CardsList<T>
{
    private List<T> _list = new List<T>();

    public event Action<T> ItemAdded;

    public void Add(T item)
    {
        _list.Add(item);
        ItemAdded?.Invoke(item); // Chiama l'evento quando un elemento viene aggiunto
    }
    
    public void Clear()
    {
        _list.Clear();
    }

    public int Count => _list.Count;

    public T this[int index] => _list[index];
}
