using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    [Header("Basic Characteristics")]
    public string Name = " ";
    public string Description = " ";
    public Sprite icon = null;

    public bool isHealing;
    public float HealingPower;
}
