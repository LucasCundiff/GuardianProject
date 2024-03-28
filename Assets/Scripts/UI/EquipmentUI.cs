using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public List<EquipmentSlotUI> slots;

    private EquippedRunes equipment;

    public Action<ItemSlotUI> onLeftClicked;
    public Action<ItemSlotUI> onRightClicked;
    public Action<ItemSlotUI> onEnter;
    public Action<ItemSlotUI> onExit;
    public Action<ItemSlotUI> onBeginDrag;
    public Action<ItemSlotUI> onDragging;
    public Action<ItemSlotUI> onEndDrag;
    public Action<ItemSlotUI> onDrop;

    private RuneItem itemCache;
    public void Init(EquippedRunes equipment)
    {
        this.equipment = equipment;

        foreach (EquipmentSlotUI EquipmentSlot in slots)
        {
            EquipmentSlot.onLeftClicked += onLeftClicked;
            EquipmentSlot.onRightClicked += onRightClicked;
            EquipmentSlot.onEnter += onEnter;
            EquipmentSlot.onExit += onExit;
            EquipmentSlot.onBeginDrag += onBeginDrag;
            EquipmentSlot.onDragging += onDragging;
            EquipmentSlot.onEndDrag += onEndDrag;
            EquipmentSlot.onDrop += onDrop;
        }
    }

    public void UpdateUI()
    {
        foreach (EquipmentSlotUI slot in slots)
        {
            if (equipment.equippedRunes.ContainsKey(slot.location))
                slot.SetItem(equipment.equippedRunes[slot.location]);
            else
                slot.SetItem(null);
        }
    }
}
