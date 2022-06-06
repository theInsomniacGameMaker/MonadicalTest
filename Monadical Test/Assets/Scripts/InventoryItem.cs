using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public ItemData Data { get; }
    public int stackCount = 0;
    
    public InventoryItem(ItemData _data)
    {
        Data = _data;
    }

    public void AddToStack()
    {
        stackCount++;
    }

    public void RemoveFromStack()
    {
        stackCount--;
        
    }
}
