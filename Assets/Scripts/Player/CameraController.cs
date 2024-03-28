using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensitivity of the mouse movement

    public Transform playerBody; // Reference to the player body to rotate it horizontally

    private float xRotation = 0f; // Rotation around the x-axis (for looking up and down)

    private PlayerInput playerInput; // Reference to the PlayerInput component
    private InputAction lookAction; // Input action for the camera look/movement

    void Awake()
    {
        playerInput = GetComponentInParent<PlayerInput>(); // Assuming this script is attached to the same GameObject as PlayerInput
        lookAction = playerInput.actions["Look"]; // "Look" should be the name of your look action in the Input Actions asset

        //Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    void Update()
    {
        // Read the mouse delta from the "Look" action
        Vector2 look = lookAction.ReadValue<Vector2>() * mouseSensitivity * Time.deltaTime;

        // Updating the xRotation for up and down movement
        xRotation -= look.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamping the rotation to prevent flipping

        // Apply the rotation for looking up and down
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player body for left and right movement
        playerBody.Rotate(Vector3.up * look.x);
    }
}