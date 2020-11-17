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

        public InteractionType interactionType;
        public UnityEvent interactAction;
        [NonSerialized] public bool isInRange;


        #region Unity Events
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

        #endregion


        private bool interactionStarted;
        private bool keyDownFired;

        private bool IsCollisionWithPlayer(Collider2D collision) => collision.gameObject.CompareTag("Player");

        void CheckForInteraction()
        {
            if (!isInRange) return;

            var interactKeyValue = controls.Player.Interact.ReadValue<float>();
            const float isPressed = 1;

            if (interactKeyValue == isPressed)
            {
                FireInteractEvent();
            }
            else
            {
                if (interactionStarted)
                {
                    FireKeyUpInteraction();
                    InteractionCleanup();
                }
            }
        }

        void FireInteractEvent()
        {
            interactionStarted = true;

            if (interactionType == InteractionType.Held)
                InvokeActions();

            if (CanFireKeyDown())
            {
                FireKeyDownInteraction();
                keyDownFired = true;
            }
        }

        private void InvokeActions()
        {
            interactAction.Invoke();
        }

        private bool CanFireKeyDown() => (interactionType == InteractionType.KeyDown && !keyDownFired);

        private void FireKeyDownInteraction() => InvokeActions();

        private void FireKeyUpInteraction() => InvokeActions();

        private void InteractionCleanup()
        {
            keyDownFired = false;
            interactionStarted = false;
        }
    }
}