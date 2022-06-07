using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Item", menuName = "Inventory Item/Create Inventory Item", order = 1)]
public class ItemData : ScriptableObject
{
    public string id;
    public string itemName;
    public Sprite icon;


    public virtual InventoryItem CreateItem()
    {
        return new InventoryItem(this);
    }
}
