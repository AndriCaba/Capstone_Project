using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 700f;
    public float maxYRotation = 80f; // Limit for looking up and down

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the game window
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize(); // Normalize to prevent faster diagonal movement

        transform.Translate(movement * speed * Time.deltaTime);
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(0f, mouseX, 0f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);

        // Vertical rotation (looking up and down)
        float currentYRotation = transform.rotation.eulerAngles.x;
        currentYRotation -= mouseY * rotationSpeed * Time.deltaTime;
        currentYRotation = Mathf.Clamp(currentYRotation, -maxYRotation, maxYRotation);

        transform.rotation = Quaternion.Euler(currentYRotation, transform.rotation.eulerAngles.y, 0f);
    }
}
