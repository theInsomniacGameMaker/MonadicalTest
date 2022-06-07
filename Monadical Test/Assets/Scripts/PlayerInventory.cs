using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour 
{
    private Dictionary<string, InventoryItem> allItems = new Dictionary<string, InventoryItem>();

    private PlayerStatManager playerStatManager;
    
    public event Action<InventoryItem> ItemAdded;
    public event Action<InventoryItem> ItemRemoved; 
    //Add a max count fot the inventory
    
    public void AddToInventory(ItemData itemData)
    {
        //Check for max count

        InventoryItem inventoryItem;
        if (allItems.ContainsKey(itemData.id))
        {
            inventoryItem = allItems[itemData.id];
            inventoryItem.AddToStack();
        }
        else
        {
            inventoryItem = itemData.CreateItem();
            allItems.Add(itemData.id, inventoryItem);
        }

        ItemAdded?.Invoke(inventoryItem);
    }

    public void EquipItem(EquippableInventoryItem item)
    {
        playerStatManager.EquipItem(item);
    }

    public void UnequipItem(EquippableInventoryItem item)
    {
        playerStatManager.UnequipItem(item);

    }
    
    
}
