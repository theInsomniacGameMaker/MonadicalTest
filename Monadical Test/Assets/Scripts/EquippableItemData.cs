using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equippable Item", menuName = "Inventory Item/Create Equippable Inventory Item", order = 1)]
public class EquippableItemData : ItemData
{
   public Stats modifiers;
}
