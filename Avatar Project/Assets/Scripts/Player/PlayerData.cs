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
        public Survival survival;
        public PlayerMovement playerMovement;
        

        #region Unity Events

        void Awake()
        {
            //TODO: try to set playerSprite programatically
            CheckPlayerSpriteValid();

            LoadPlayerSurvival();
            AddPlayerMovement();
        }

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        #endregion


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


        private void LoadPlayerSurvival()
        {
            playerSprite.AddComponent<Survival>();
            survival = playerSprite.GetComponent<Survival>();
        }
    }
}
