using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Main instance of game. Useful for managing info related to a game session. Ex: The instance of the player, the map, etc
    /// </summary>
    public class Game : MonoBehaviour
    {
        public static Game instance;
        public Player.PlayerData player;

        void Awake()
        {
            
        }

        void Start()
        {
            instance = this;
        }

        void Update()
        {

        }
    }
}