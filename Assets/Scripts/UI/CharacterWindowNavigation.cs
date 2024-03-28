using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterWindowNavigation : MonoBehaviour
{
    public List<NavigationButton> buttons = new List<NavigationButton>();

    private void OnEnable()
    {
        foreach (NavigationButton navigationButton in buttons)
        {
            navigationButton.OnClickEvent += ToggleButtons;
        }
    }

    private void Start()
    {
        if (buttons.Count <= 0) 
        {
            buttons = GetComponentsInChildren<NavigationButton>(includeInactive: true).ToList();
        }

        ToggleButtons(buttons[0]);
    }

    private void ToggleButtons(NavigationButton button)
    {
        foreach (NavigationButton navigationButton in buttons)
        {
            navigationButton.ToggleState(button == navigationButton);
        }
    }

    private void OnDisable()
    {
        foreach (NavigationButton navigationButton in buttons)
        {
            navigationButton.OnClickEvent -= ToggleButtons;
        }
    }
}
