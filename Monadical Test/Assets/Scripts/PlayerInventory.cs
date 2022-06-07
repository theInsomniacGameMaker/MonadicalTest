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

    private void Awake()
    {
        playerStatManager = GetComponent<PlayerStatManager>();
    }

    public void AddToInventory(ItemData itemData, bool addingFromEquippedItems = false)
    {
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

    public void RemoveFromInventory(ItemData itemData, bool addingToEquippedItems = false)
    {
        if (allItems.ContainsKey(itemData.id))
        {
            InventoryItem inventoryItem = allItems[itemData.id];
            if (inventoryItem.stackCount > 0)
            {
                inventoryItem.RemoveFromStack();
                ItemRemoved?.Invoke(inventoryItem);
            }
        }
        else
        {
            Debug.LogError("Trying to remove an item that isn't  in the inventory.");
        }
    }

    public void EquipItem(EquippableInventoryItem item)
    {
        if (playerStatManager.EquipItem(item))
        {
            RemoveFromInventory(item.Data);
        }
    }

    public void UnequipItem(EquippableInventoryItem item)
    {
        if (playerStatManager.UnequipItem(item))
        {
            AddToInventory(item.Data);
        }
    }


}
