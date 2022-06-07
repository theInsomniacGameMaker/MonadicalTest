using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    [SerializeField] private Stats maxValues;

    private Stats currentValues;

    private HashSet<EquippableInventoryItem> equippedItems = new HashSet<EquippableInventoryItem>();

    public event Action StatsUpdated;
    
    public Stats CurrentValues
    {
        get => currentValues;
        set
        {
            currentValues = value;
            StatsUpdated?.Invoke();
        }
    }

    public Stats MaxValues
    {
        get => maxValues;
        set
        {
            maxValues = value;
            StatsUpdated?.Invoke();
        }
    }

    private void Awake()
    {
        CurrentValues = MaxValues;
    }

    public bool EquipItem(EquippableInventoryItem item)
    {
        if (equippedItems.Contains(item))
        {
            return false;
        }
        equippedItems.Add(item);
        MaxValues += item.GetStats();
        return true;
    }

    public bool UnequipItem(EquippableInventoryItem item)
    {
        if (!equippedItems.Contains(item))
        {
            return false;
        } 
        equippedItems.Remove(item);
        MaxValues -= item.GetStats();
        return true;

    }

    public bool IsItemEquipped(ItemData itemData)
    {
        return equippedItems.FirstOrDefault(i => i.Data = itemData)!=null;
    }
}
