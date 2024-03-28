using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    public List<RuneItem> items = new List<RuneItem>();

    // Define events for adding and removing items
    public event Action<RuneItem> OnItemAdded;
    public event Action<RuneItem> OnItemRemoved;

    public bool AddItem(RuneItem item)
    {
        items.Add(item);
        OnItemAdded?.Invoke(item);
        return true;
    }

    public bool RemoveItem(RuneItem item)
    {
        bool removed = items.Remove(item);
        if (removed)
        {
            OnItemRemoved?.Invoke(item);
        }
        return removed;
    }
}
