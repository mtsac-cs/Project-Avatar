using System;
using System.Net.Http.Headers;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Individual attributes like strength, speed, defense, etc
    /// </summary>
    public class PlayerAttribute
    {
        public string statName;
        public string statDescription;

        public int StatLevel { get; private set; } = 0;
        public int maxStatLevel = 10;

        private bool shownMaxLevelMessage = false;
        public PlayerAttribute()
        {

        }

        public void RaiseStat() => RaiseStat(1);

        public void RaiseStat(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Can't raise stat by negative number", "amount");

            if (StatLevel == maxStatLevel)
                return;

            if (StatLevel + amount >= maxStatLevel)
            {
                StatLevel = maxStatLevel;
                if (!shownMaxLevelMessage)
                    ShowMaxLevelMsg();

                return;
            }

            StatLevel += amount;            
        }

        private void ShowMaxLevelMsg()
        {
            string msg = $"Congrats!!! Your {statName} reached max level!";
            Debug.Log(msg);

            shownMaxLevelMessage = true;
        }
    }
}
