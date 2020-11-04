using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public fields accessible by the class methods.  As they are public, 
    // Unity should give access to change their values as well
    public float moveSpeed;
    public Rigidbody2D rb;

    // Private field only accessible within this class
    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        // Processing inputs...defined below
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        // Physics Calculations
        Move();
    }

    // Will obtain user input and process them to update on viewport
    void ProcessInputs()
    {
        // Assigns raw values from player axis inputs (x direction and y direction)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Updates direction of player with player input vectors.  
        moveDirection = new Vector2(moveX, moveY).normalized; // .normalized makes it so that vertical movement does not move faster than horizontal vs vertical
    }

    // Calculates velocity of player by calculating movement direction with moveSpeed scalar
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
