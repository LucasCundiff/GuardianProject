using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NavigationButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject targetWindow;
    public Image activeIndicator;
    public TextMeshProUGUI nameText;

    public Color enabledColor = Color.white;
    public Color hoverDisabledColor = Color.white;
    public Color disabledColor = Color.gray;

    public Action<NavigationButton> OnClickEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnClickEvent?.Invoke(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!activeIndicator.enabled)
            nameText.color = hoverDisabledColor; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        nameText.color = activeIndicator.enabled ? enabledColor : disabledColor;
    }

    public void ToggleState(bool state)
    {
        targetWindow.SetActive(state);
        activeIndicator.enabled = state;
        nameText.color = state ? enabledColor : disabledColor;
    }
}
