using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Manages data related to an instance of player. Ex: Survival stats, save data, sprite, etc
    /// </summary>
    public class PlayerData : MonoBehaviour
    {
        public GameObject playerSprite;
        [NonSerialized] public Survival survival;
        [NonSerialized] public PlayerMovement playerMovement;


        void Awake()
        {
            CheckPlayerSpriteValid();
            AddPlayerMovement();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void CheckPlayerSpriteValid()
        {
            if (playerSprite is null) 
                throw new Exception("PlayerSprite was not set! It must be set for PlayerData class to work properly");
        }

        private void AddPlayerMovement()
        {
            playerSprite.AddComponent<PlayerMovement>();
            playerMovement = playerSprite.GetComponent<PlayerMovement>();
        }
    }
}
