using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float defaultSpeed = 12f;
    public float walkSpeed = 9f; // Tốc độ di chuyển khi Walk
    public float runSpeed = 18f; // Tốc độ di chuyển khi Run
    public float crouchSpeed = 6f; // Tốc độ di chuyển khi Crouch
    public float gravity = -9.8f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isCrouching;

    float standingHeight = 2f;
    float crouchingHeight = 1f;
    Vector3 standingCameraPosition = Vector3.up;
    Vector3 crouchingCameraPosition = Vector3.up * 0.5f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
       
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Kiểm tra nút Ctrl để thay đổi speed thành 9f khi Walk
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (isCrouching)
            {
            speed = crouchSpeed;
            }
            else 
            {
            speed = walkSpeed;
            }                    
        }
        else
        {
            // Kiểm tra nút Shift để thay đổi speed thành 18f khi Run
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (isCrouching) // Nếu đang crouch thì tự trả lại stand trước khi Run
                {
                    isCrouching = false;
                }
                else
                {
                    speed = runSpeed; // Speed trở về runSpeed sau khi chuyển từ crouch về stand
                }
            }
            else
            {                     
                if (isCrouching)
                {
                speed = crouchSpeed;
                }
                else
                {
                speed = defaultSpeed; // trả lại speed mặc định nếu ko run ko walk và ko crouch
                }                
            }
        }

        // Kiểm tra nút C để chuyển trạng thái giữa stand và crouch
       if (Input.GetKeyDown(KeyCode.C))
        {
            if (!isCrouching) // Nếu đang stand, chuyển sang trạng thái crouch
            {
                isCrouching = true;
                speed = crouchSpeed;
            }
            else // Nếu đang crouch, chuyển sang trạng thái stand
            {
                isCrouching = false;
                speed = defaultSpeed;
            }
        }
            // Kiểm tra nút Space để nhảy
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

        float targetHeight = isCrouching ? crouchingHeight : standingHeight;
        float targetCameraPosition = isCrouching ? crouchingCameraPosition.y : standingCameraPosition.y;
        controller.height = Mathf.Lerp(controller.height, targetHeight, Time.deltaTime * 5f);
        Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Mathf.Lerp(Camera.main.transform.localPosition.y, targetCameraPosition, Time.deltaTime * 5f), Camera.main.transform.localPosition.z);

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
