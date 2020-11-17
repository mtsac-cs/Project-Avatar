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
        [NonSerialized] public PlayerLevel playerLevel;
        [NonSerialized] public PlayerStats playerStats;
        [NonSerialized] public PlayerMovement playerMovement;

        
        #region Unity Events

        void Awake()
        {
            CheckPlayerSpriteValid();

            AddPlayerStats();
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

        private void AddPlayerStats()
        {
            playerStats = new PlayerStats();
        }
    }
}
