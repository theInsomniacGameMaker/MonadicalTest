using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class StatsDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statsText;
    [SerializeField] private PlayerStatManager playerStatManager;
    private void Awake()
    {
        playerStatManager.StatsUpdated += UpdateStats;
        UpdateStats();
    }
    
    private void UpdateStats()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Health {playerStatManager.CurrentValues.health} / {playerStatManager.MaxValues.health}\n");
        stringBuilder.Append($"Mana {playerStatManager.CurrentValues.mana} / {playerStatManager.MaxValues.mana}\n");
        stringBuilder.Append($"Intelligence {playerStatManager.CurrentValues.intelligence} / {playerStatManager.MaxValues.intelligence}\n");
        stringBuilder.Append($"Endurance {playerStatManager.CurrentValues.endurance} / {playerStatManager.MaxValues.endurance}\n");
        statsText.text = stringBuilder.ToString();
    }
}
