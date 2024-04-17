using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject inventoryUI; // Reference to the Inventory UI

    Vector3 velocity;
    bool isGrounded;
    bool isInventoryOpen = false; // Flag to track if the Inventory is open

    void Update()
    {
        // Check if the Inventory should be opened
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInventoryOpen = !isInventoryOpen; // Toggle the state of the Inventory
            inventoryUI.SetActive(isInventoryOpen); // Set the Inventory UI active or inactive based on the state
            Time.timeScale = isInventoryOpen ? 0f : 1f; // Pause or resume the game time based on the Inventory state
            Cursor.lockState = isInventoryOpen ? CursorLockMode.None : CursorLockMode.Locked; // Unlock or lock the cursor based on the Inventory state
            Cursor.visible = isInventoryOpen; // Show or hide the cursor based on the Inventory state
        }

        if (!isInventoryOpen)
        {
            // Player movement
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            // Apply gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
