using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Behaviors
{
    /// <summary>
    /// This class makes objects interactable
    /// </summary>
    public class Interactable : MonoBehaviour
    {
        private Controls controls;
        public bool isInRange;
        public UnityEvent interactAction;

        void Awake()
        {
            
        }

        void Start()
        {
            controls = Game.instance.controls;
        }

        void Update()
        {
            CheckForInteraction();
        }

        void CheckForInteraction()
        {
            if (!isInRange) return;

            var interactKeyValue = controls.Player.Interact.ReadValue<float>();
            const float isPressed = 1;

            if (interactKeyValue == isPressed)
                FireInteractEvent();
        }

        void FireInteractEvent() => interactAction.Invoke();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsCollisionWithPlayer(collision))
                isInRange = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (IsCollisionWithPlayer(collision))
                isInRange = false;
        }

        private bool IsCollisionWithPlayer(Collider2D collision) => collision.gameObject.CompareTag("Player");

        public void OnInteraction()
        {
            throw new NotImplementedException("You need to override OnInteraction and specify player interaction");
        }
    }
}