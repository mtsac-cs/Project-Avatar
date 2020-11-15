using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Behaviors
{
    /// <summary>
    /// This class makes objects interactable
    /// </summary>
    public class Interactable : MonoBehaviour
    {
        public bool isInRange;
        private Controls controls;
        public UnityEvent interactAction;

        void Start()
        {
            controls = new Controls();
        }

        void Update()
        {
            CheckForInteraction();
        }

        void CheckForInteraction()
        {
            if (!isInRange) return;

            var interactKey = controls.Player.Interact;
            const float isPressed = 1;

            if (interactKey.ReadValue<float>() == isPressed)
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
    }
}
