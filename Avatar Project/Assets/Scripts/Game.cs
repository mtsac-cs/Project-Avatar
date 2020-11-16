using Assets.Scripts.Extensions;
using Assets.Scripts.Player;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    /// <summary>
    /// Main instance of game. Useful for managing info related to a game session. Ex: The instance of the player, the map, etc
    /// </summary>
    public class Game : MonoBehaviour
    {
        public Controls controls;
        public PlayerData playerData;
        public static Game instance;


        #region Unity Events

        void Awake()
        {
            if (instance is null)
                instance = this;

            controls = new Controls();
        }

        void Start()
        {
            
        }


        void Update()
        {
            if (playerData is null)
                SetPlayerData();
        }

        private void OnEnable() => controls.Enable();
        private void OnDisable() => controls.Disable();


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoadRuntimeMethod()
        {

        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void OnAfterSceneLoadRuntimeMethod()
        {
            AddGameToScene();
        }

        #endregion


        private static void AddGameToScene()
        {
            var gameObject = Instantiate(new GameObject());
            gameObject.AddComponent<Game>();
        }

        private void SetPlayerData()
        {
            var allPlayers = SceneManager.GetActiveScene().FindAllGameObjectsWithTag("Player");
            var playerGameObject = allPlayers[0];
            var playerData = playerGameObject.GetComponent<PlayerData>();

            if (playerData != null)
                playerData = this.playerData;
            else
                throw new Exception("Game object failed to get the Player from scene");
        }
    }
}