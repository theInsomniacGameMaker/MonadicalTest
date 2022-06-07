using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Button addButton;

    private ItemData itemData;
    public event Action<ItemData> AddItemToInventory;
    private ShopUI shopReference;
    public void Initialize(ItemData _itemData, ShopUI shopUI)
    {
        itemData = _itemData;
        shopReference = shopUI;
        iconImage.sprite = itemData.icon;
        nameText.text = itemData.itemName;
        addButton.onClick.AddListener(AddButtonPressed);
        
    }

    private void AddButtonPressed()
    {
        shopReference.AddItemToInventory(itemData);
    }


}
