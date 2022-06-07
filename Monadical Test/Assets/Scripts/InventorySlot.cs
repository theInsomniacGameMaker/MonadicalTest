using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Button selfButton;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI countText;
    
    private InventoryUIController inventoryUIControllerReference;
    public void Initialize(InventoryItem inventoryItem, InventoryUIController inventoryUIController)
    {
        inventoryItem.stackCount = 1;
        iconImage.sprite = inventoryItem.Data.icon;
        nameText.text = inventoryItem.Data.itemName;
        countText.text = inventoryItem.stackCount.ToString();
        inventoryUIControllerReference = inventoryUIController;
        selfButton.onClick.AddListener(SlotClicked);
    }

    public void RefreshCount(int newCount)
    {
        countText.text = newCount.ToString();
    }
    
    private void SlotClicked()
    {
        inventoryUIControllerReference.SelectSlot(this);
    }
}
