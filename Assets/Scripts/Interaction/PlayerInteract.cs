using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 2.0f;
    public LayerMask interactableLayer; // Set this in the Inspector
    public TMPro.TextMeshProUGUI interactionPrompt;

    private IInteractable currentInteractable;

    void Update()
    {
        DetectInteractable();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null) // Assuming 'E' is the interact key
        {
            currentInteractable.Interact(gameObject);
        }
    }

    void DetectInteractable()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactRange, interactableLayer))
        {
            var interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (currentInteractable != interactable)
                {
                    currentInteractable = interactable;
                    interactionPrompt.text = interactable.GetInteractionPrompt();
                }
            }
        }
        else if (currentInteractable != null)
        {
            currentInteractable = null;
            interactionPrompt.text = "";
        }
    }
}
