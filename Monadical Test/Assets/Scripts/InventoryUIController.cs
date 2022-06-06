using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] private GameObject inventorySlotPrefab;

    [Header("References")]
    [SerializeField] private PlayerInventory playerInventory;
    
    
    private Dictionary<InventorySlot, InventoryItem> slots;
    
    
    
    private void Awake()
    {
        playerInventory.ItemAdded += PlayerInventoryItemAdded;
        slots = new Dictionary<InventorySlot, InventoryItem>();
    }

    private void PlayerInventoryItemAdded(InventoryItem inventoryItem)
    {
        if (slots.ContainsValue(inventoryItem))
        {
            InventorySlot slot = slots.FirstOrDefault(i => i.Value == inventoryItem).Key;
            slot.RefreshCount(inventoryItem.stackCount);
        }
        else
        {
            InventorySlot newSlot = CreateNewInventorySlot();
            slots.Add(newSlot, inventoryItem);
            newSlot.Initialize(inventoryItem);
        }
    }


    //This should be using object pooling. 
    private InventorySlot CreateNewInventorySlot()
    {
        return Instantiate(inventorySlotPrefab, this.transform).GetComponent<InventorySlot>();
    }
}
