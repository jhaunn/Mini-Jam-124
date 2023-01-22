using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private TextMeshPro inventoryText;

    [SerializeField] private int maxInventory;
    private int currentInventory = 0;
    private int inventoryScore = 0;

    private void Update()
    {
        inventoryText.text = $"{currentInventory}/{maxInventory}";
    }

    public void AddInventory(int score)
    {
        currentInventory++;
        inventoryScore += score;
    }

    public bool CheckInventory()
    {
        return currentInventory < maxInventory;
    }
}
