﻿using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Manages all player attributes
    /// </summary>
    public class PlayerStats
    {
        public PlayerAttribute attack, defense, movementSpeed;

        public PlayerStats()
        {
            movementSpeed = new PlayerAttribute()
            {
                statName = "Movement Speed",
                statDescription = "How fast your player moves",
                maxStatLevel = 10
            };
        }
    }
}
