using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 80f;

    public Transform mainPlayer;
    bool IsOpenInventory;
    float xRotation = 0f;
    void Start()
    {
        IsOpenInventory = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!IsOpenInventory)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            mainPlayer.Rotate(Vector3.up * mouseX);
        }
    }
}
