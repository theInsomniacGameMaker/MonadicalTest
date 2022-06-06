using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Item", menuName = "Inventory Item/Create Inventory Item", order = 1)]
public class ItemData : ScriptableObject
{
    public string id;
    public string name;
    public Sprite icon;
}
