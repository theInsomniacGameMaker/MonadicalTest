using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [SerializeField] private Button inventoryButton;
   [SerializeField] private Button shopButton;
   [SerializeField] private GameObject inventoryPanel;
   [SerializeField] private GameObject shopPanel;

   private void Awake()
   {
      inventoryButton.onClick.AddListener(ToggleSpaces);
      shopButton.onClick.AddListener(ToggleSpaces);
   }

   private void ToggleSpaces()
   {
      inventoryButton.interactable = !inventoryButton.interactable;
      shopButton.interactable = !shopButton.interactable;
      inventoryPanel.SetActive(!inventoryPanel.activeSelf);
      shopPanel.SetActive(!shopPanel.activeSelf);
   }
}
