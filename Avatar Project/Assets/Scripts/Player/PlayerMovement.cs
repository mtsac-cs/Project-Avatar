using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Script that controls the movement for the player
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [NonSerialized] public float walkSpeed = 5f;
        [NonSerialized] public float sprintSpeed = 10f;
        [NonSerialized] public Controls controls;
        private Rigidbody2D rb;


        void Start()
        {
            controls = Game.instance.controls;
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            MovePlayer();
        }

        void MovePlayer()
        {
            Vector2 movementInput = controls.Player.Move.ReadValue<Vector2>().normalized;
            //movementInput = movementInput.normalized;
            rb.AddForce(movementInput * GetMovementSpeed());
        }

        float GetMovementSpeed()
        {
            var sprintKeyValue = controls.Player.Sprint.ReadValue<float>();
            const float keyPressed = 1;

            bool isSprintKeyPressed = (sprintKeyValue == keyPressed);
            return isSprintKeyPressed ? sprintSpeed : walkSpeed;
        }
    }
}
