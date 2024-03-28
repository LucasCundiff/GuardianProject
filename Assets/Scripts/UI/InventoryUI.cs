using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<ItemSlotUI> slots = new List<ItemSlotUI>();

    private Inventory inventory;

    public Action<ItemSlotUI> onLeftClicked;
    public Action<ItemSlotUI> onRightClicked;
    public Action<ItemSlotUI> onEnter;
    public Action<ItemSlotUI> onExit;
    public Action<ItemSlotUI> onBeginDrag;
    public Action<ItemSlotUI> onDragging;
    public Action<ItemSlotUI> onEndDrag;
    public Action<ItemSlotUI> onDrop;

    public void Init(Inventory inventory)
    {
        this.inventory = inventory;

        foreach (ItemSlotUI itemSlot in slots)
        {
            itemSlot.onLeftClicked += onLeftClicked;
            itemSlot.onRightClicked += onRightClicked;
            itemSlot.onEnter += onEnter;
            itemSlot.onExit += onExit;
            itemSlot.onBeginDrag += onBeginDrag;
            itemSlot.onDragging += onDragging;
            itemSlot.onEndDrag += onEndDrag;
            itemSlot.onDrop += onDrop;
        }
    }

    public void UpdateUI()
    {
        if (slots.Count < inventory.items.Count) Debug.Log("More Items than slots, something has gone wrong");

        int i = 0;
        for (; i < inventory.items.Count; i++)
        {
            slots[i].SetItem(inventory.items[i]);
            slots[i].gameObject.SetActive(true);
        }
        for (; i < slots.Count; i++)
        {
            slots[i].gameObject.SetActive(false);
        }
    }
}
