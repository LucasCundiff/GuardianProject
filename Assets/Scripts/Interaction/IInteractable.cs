using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject player); // The player object interacting with this
    string GetInteractionPrompt(); // Provides a prompt or description for the UI
}
