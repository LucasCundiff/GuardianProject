using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] Inventory inventory = new Inventory();
    [SerializeField] EquippedRunes equippedRunes = new EquippedRunes();
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] EquipmentUI equipmentUI;
    [SerializeField] ItemTooltip itemTooltip;
    [SerializeField] ItemSlotUI previousSlot;
    [SerializeField] ItemSlotUI draggingSlot;

    public Animator animator;
    public CharacterStats stats;

    private RuneItem dragItemCache;
    private RuneItem dropItemCache;

    protected void Awake()
    {
        inventoryUI.onEnter += itemTooltip.ShowTooltip;
        inventoryUI.onExit += _ => itemTooltip.HideTooltip();
        inventoryUI.onBeginDrag += OnBeginDrag;
        inventoryUI.onDragging += OnDragging;
        inventoryUI.onEndDrag += OnEndDrag;
        inventoryUI.onDrop += OnDrop;
        inventoryUI.Init(inventory);

        equipmentUI.onEnter += itemTooltip.ShowTooltip;
        equipmentUI.onExit += _ => itemTooltip.HideTooltip();
        equipmentUI.onBeginDrag += OnBeginDrag;
        equipmentUI.onDragging += OnDragging;
        equipmentUI.onEndDrag += OnEndDrag;
        equipmentUI.onDrop += OnDrop;
        equipmentUI.Init(equippedRunes);

        inventory.OnItemAdded += _ => UpdateInventoryUI();
        inventory.OnItemRemoved += _ => UpdateInventoryUI();

        equippedRunes.OnRuneEquipped += _ => UpdateEquipmentUI();
        equippedRunes.OnRuneUnequipped += _ => UpdateEquipmentUI();

        draggingSlot.gameObject.SetActive(false);
    }

    private void Start()
    {
        UpdateInventoryUI();
        UpdateEquipmentUI();
    }
    public void OnBeginDrag(ItemSlotUI itemSlot)
    {
        if (itemSlot.item == null) return;
        draggingSlot.SetItem(itemSlot.item);
        draggingSlot.gameObject.SetActive(true);
        previousSlot = itemSlot;
    }

    public void OnDragging(ItemSlotUI itemSlot)
    {
        draggingSlot.gameObject.transform.position = Mouse.current.position.ReadValue();
    }

    public void OnEndDrag(ItemSlotUI itemSlot)
    {
        draggingSlot.gameObject.SetActive(false);
        previousSlot = null;
    }

    public void OnDrop(ItemSlotUI itemSlot)
    {
        if (itemSlot.item == null || previousSlot.item == null) return;
        dragItemCache = previousSlot.item;
        dropItemCache = itemSlot.item;
        Debug.Log($"Drop item is {itemSlot.item} and its type is {itemSlot.GetType()}");
        Debug.Log($"Drag item is {previousSlot.item} and its type is {previousSlot.GetType()}");
    }
    public void EquipItem(EquipLocation location, RuneItem item)
    {
        equippedRunes.EquipItem(location, item);

    }
    public void UnequipItem(EquipLocation location)
    {
        equippedRunes.UnequipItem(location);
    }

    public void OnEquipItem(RuneItem item)
    {
        item.Equip(this);
    }

    public void OnUnequipItem(RuneItem item)
    {
        item.Unequip(this);
        AddItem(item);
    }

    public void AddItem(RuneItem item) => inventory.AddItem(item);
    public void RemoveItem(RuneItem item) => inventory.RemoveItem(item);

    private void UpdateInventoryUI()
    {
        inventoryUI.UpdateUI();
    }
    private void UpdateEquipmentUI()
    {
        equipmentUI.UpdateUI();
    }
}