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

        void Awake()
        {
            controls = new Controls();
        }
        private void OnEnable()
        {
            controls.Enable();
        }
        private void OnDisable()
        {
            controls.Disable();
        }
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            MovePlayer();
        }

        void MovePlayer()
        {
            Vector2 movementInput = controls.Player.Move.ReadValue<Vector2>();
            movementInput = movementInput.normalized;
            rb.AddForce(movementInput * GetMovementSpeed());
        }

        float GetMovementSpeed()
        {
            float sprintKeyValue = controls.Player.Sprint.ReadValue<float>();
            const float keyPressed = 1;

            bool isSprintKeyPressed = (sprintKeyValue == keyPressed);
            return isSprintKeyPressed ? sprintSpeed : walkSpeed;
        }
    }
}
