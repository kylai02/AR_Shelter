using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Public variable to adjust the speed

    private Rigidbody rb; // To apply physics-based movement
    private Vector3 movement; // To store movement direction
    private float movementX;
    private float movementZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        // Input detection for movement
        movementX = Input.GetAxisRaw("Horizontal"); // A and D keys
        movementZ = Input.GetAxisRaw("Vertical"); // W and S keys

        movement = new Vector3(movementX, 0, movementZ).normalized; // Normalize to ensure consistent speed in all directions
    }

    // FixedUpdate is called at a fixed interval and is used to apply physics-based movements
    void FixedUpdate()
    {
        // Apply movement to the Rigidbody
        MoveCharacter(movement);

        if (movement != Vector3.zero)
        {
            // Rotate the character to face the direction of movement
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, moveSpeed * 100 * Time.fixedDeltaTime);
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        // Move the character
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}