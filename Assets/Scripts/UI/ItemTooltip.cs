using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemTooltip : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public void Awake()
    {
        HideTooltip();
    }

    private void Update()
    {
        transform.position = Mouse.current.position.ReadValue();
    }

    public void ShowTooltip(ItemSlotUI itemSlot)
    {
        if (itemSlot.item == null)
            return;

        nameText.text = itemSlot.item.itemName;
        descriptionText.text = itemSlot.item.GetDescription();

        transform.position = Mouse.current.position.ReadValue();
        gameObject.SetActive(true);

    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
