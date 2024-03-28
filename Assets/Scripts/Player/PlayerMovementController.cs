using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    //movement 
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float currentMovespeed = 0f;
    public bool sprintFlag = false;
    private Vector2 moveInput;

    //crouch
    public float crouchHeight = 0.5f;
    private float originalHeight;
    private bool isCrouching = false;

    //jump
    public Transform groundCheck;
    public LayerMask groundLayers;
    private bool isGrounded;
    public float jumpForce = 7f;
    private bool jumpFlag;

    //dash
    private float dashForce = 10f;

    //Physics controllers
    private Rigidbody rb;
    private CapsuleCollider playerCollider;

    //Player input
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction crouchAction;
    private InputAction sprintAction;
    private InputAction dashAction;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        playerCollider = GetComponent<CapsuleCollider>();
        originalHeight = playerCollider.height;

        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        crouchAction = playerInput.actions["Crouch"];
        sprintAction = playerInput.actions["Sprint"];
        dashAction = playerInput.actions["Dash"];

        jumpAction.performed += _ => TriggerJumpFlag();
        crouchAction.performed += _ => ToggleCrouch();
        sprintAction.started += _ => ToggleSprint();
        sprintAction.canceled += _ => ToggleSprint();
        dashAction.performed += _ => Dash();

        currentMovespeed = walkSpeed;
    }

    void OnDisable()
    {
        // Unsubscribe from the actions
        jumpAction.performed -= _ => TriggerJumpFlag();
        crouchAction.performed -= _ => ToggleCrouch();
        sprintAction.started -= _ => ToggleSprint();
        sprintAction.canceled -= _ => ToggleSprint();
        dashAction.performed -= _ => Dash();
    }

    void Update()
    {
        CheckGroundStatus();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        if (jumpFlag)
            Jump();
    }

    void MovePlayer()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        rb.MovePosition(transform.position + move * currentMovespeed * Time.deltaTime);
    }

    void CheckGroundStatus()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);
    }
    private void TriggerJumpFlag()
    {
        jumpFlag = true;
    }

    void Jump()
    {
        if (isGrounded && jumpFlag)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        jumpFlag = false;
    }

    void ToggleCrouch()
    {
        isCrouching = !isCrouching;
        playerCollider.height = isCrouching ? crouchHeight : originalHeight;
    }


    private void ToggleSprint()
    {
        sprintFlag = !sprintFlag;
        currentMovespeed = sprintFlag ? sprintSpeed : walkSpeed;
    }


    private void Dash()
    {
        rb.AddForce(Camera.main.transform.forward * dashForce, ForceMode.Impulse);
    }
}