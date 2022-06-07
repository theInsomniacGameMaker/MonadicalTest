using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] private GameObject inventorySlotPrefab;
    [SerializeField] private GameObject layoutPanel;
    [SerializeField] private RectTransform slotSelector;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button unequipButton;

    [Header("References")]
    [SerializeField] private PlayerInventory playerInventory;
    
    private Dictionary<InventorySlot, InventoryItem> slots;
    private InventorySlot selectedSlot;
    
    private void Awake()
    {
        playerInventory.ItemAdded += PlayerInventoryItemAdded;
        slots = new Dictionary<InventorySlot, InventoryItem>();
        equipButton.onClick.AddListener(EquipItem);
        unequipButton.onClick.AddListener(UnequipItem);
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
            newSlot.Initialize(inventoryItem, this);
        }
    }


    private InventorySlot CreateNewInventorySlot()
    {
        //This should be using object pooling. 
        return Instantiate(inventorySlotPrefab, layoutPanel.transform).GetComponent<InventorySlot>();
    }

    public void SelectSlot(InventorySlot slot)
    {
        selectedSlot = slot;
        slotSelector.position = slot.transform.position;
    }

    public void EquipItem()
    {
        if (slots[selectedSlot] is EquippableInventoryItem item)
        {
            playerInventory.EquipItem(item);
        }
    }
    
    public void UnequipItem()
    {
        if (slots[selectedSlot] is EquippableInventoryItem item)
        {
            playerInventory.UnequipItem(item);
        }
    }
}
