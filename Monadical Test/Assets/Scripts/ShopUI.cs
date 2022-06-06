using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
   [SerializeField] private ItemData[] items;
   [SerializeField] private GameObject shopSlotPrefab;
   
   [Header("References")]
   [SerializeField] private PlayerInventory playerInventory;

   
   private void Awake()
   {
      foreach (ItemData item in items)
      {
          var temp = Instantiate(shopSlotPrefab, this.transform).GetComponent<ShopSlot>();
          temp.Initialize(item, this);
      }
   }

   public void AddItemToInventory(ItemData itemData)
   {
       playerInventory.AddToInventory(itemData);
   }
   
}
