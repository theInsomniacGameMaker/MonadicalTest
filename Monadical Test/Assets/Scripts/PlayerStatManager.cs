using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    [SerializeField] private Stats maxValues;

    private Stats currentValues;

    private HashSet<EquippableInventoryItem> equippedItems;

    public Stats CurrentValues
    {
        get => currentValues;
        set => currentValues = value;
    }

    public Stats MaxValues
    {
        get => maxValues;
        set => maxValues = value;
    }

    private void Awake()
    {
        CurrentValues = MaxValues;
    }

    public void EquipItem(EquippableInventoryItem item)
    {
        MaxValues += item.GetStats();
    }

    public void UnequipItem(EquippableInventoryItem item)
    {
        MaxValues -= item.GetStats();
    }
    
    
}
