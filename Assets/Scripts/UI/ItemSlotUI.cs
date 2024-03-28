using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    public Vector2 normalSize = new Vector2(1, 1); // Normal size of the slot
    public Vector2 hoverSize = new Vector2(1.4f, 1.4f); // Size of the slot on hover
    public Image itemImage;
    
    private RectTransform rectTransform;
    public RuneItem item { get; private set; }

    public Action<ItemSlotUI> onLeftClicked; 
    public Action<ItemSlotUI> onRightClicked; 
    public Action<ItemSlotUI> onEnter; 
    public Action<ItemSlotUI> onExit; 
    public Action<ItemSlotUI> onBeginDrag; 
    public Action<ItemSlotUI> onDragging; 
    public Action<ItemSlotUI> onEndDrag;
    public Action<ItemSlotUI> onDrop;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetItem(RuneItem newItem)
    {
        item = newItem;
        if (item != null)
        {
            itemImage.sprite = item.itemSprite;
            itemImage.enabled = true;
        }
        else
            itemImage.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.localScale = hoverSize; // Increase size on hover
        onEnter?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = normalSize; // Revert to normal size
        onExit?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        onDragging?.Invoke(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        onBeginDrag?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onEndDrag?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        onDrop?.Invoke(this);
    }
}
