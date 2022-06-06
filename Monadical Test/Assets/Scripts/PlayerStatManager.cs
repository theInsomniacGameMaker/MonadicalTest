using System;
using UnityEngine;

[System.Serializable]
public struct Stats
{
    public int health;
    public int mana;
    public int endurance;
    public int intelligence;
}

public class PlayerStatManager : MonoBehaviour
{
    [SerializeField] private Stats maxValues;

    private Stats currentValues;
    
    private void Awake()
    {
        currentValues = maxValues;
    }
    
    
}
