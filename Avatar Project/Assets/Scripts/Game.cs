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
        public static Game instance;
        public Player.PlayerData player;
        

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoadRuntimeMethod()
        {

        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void OnAfterSceneLoadRuntimeMethod()
        {
            AddGameToScene();
        }

        private static void AddGameToScene()
        {
            var gameObject = Instantiate(new GameObject());
            gameObject.AddComponent<Game>();
        }


        void Awake()
        {
            if (instance is null)
                instance = this;
        }

        void Start()
        {
            
        }


        void Update()
        {
            if (player is null)
                SetPlayerData();
        }

        private void SetPlayerData()
        {
            var allPlayers = SceneManager.GetActiveScene().FindAllGameObjectsWithTag("Player");
            var playerGameObject = allPlayers[0];
            var tempPlayer = playerGameObject.GetComponent<PlayerData>();

            if (tempPlayer is null) throw new Exception("Game object failed to get the Player from scene");
            else
                player = tempPlayer;
        }
    }
}