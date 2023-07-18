using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public Transform SlotsParent;

    bool isOpened;

    private InventorySlot[] inventorySlots = new InventorySlot[18];

    private void Start()
    {
        instance = this;

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i] = SlotsParent.GetChild(i).GetComponent<InventorySlot>();
        }
    }

    public void PutInEmptySlot(Item item, GameObject obj)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].SlotItem == null)
            {
                inventorySlots[i].PutInSlot(item, obj);
                return;
            } 
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        { 
            if (isOpened)
                Close();
            else
                Open();
        }
    }

    void Open()
    {
        gameObject.transform.localScale = Vector3.one;
        isOpened = true;
    }

    void Close() 
    {
        gameObject.transform.localScale = Vector3.zero;
        isOpened = false;
    }
}
