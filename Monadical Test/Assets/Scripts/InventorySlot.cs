using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI countText;
    
    public void Initialize(InventoryItem inventoryItem)
    {
        iconImage.sprite = inventoryItem.Data.icon;
        nameText.text = inventoryItem.Data.name;
        countText.text = inventoryItem.stackCount.ToString();
    }

    public void RefreshCount(int newCount)
    {
        countText.text = newCount.ToString();
    }
}
