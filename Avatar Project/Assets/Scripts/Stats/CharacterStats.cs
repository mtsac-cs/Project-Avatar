using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Stats;

/// <summary>
/// Holds a list of base stats that all characters in the game should have
/// </summary>

namespace Assets.Scripts.Stats
{
    [System.Serializable]
    public class CharacterStats
    {
        [SerializeField]
        private CharacterStat[] stats;

        //key for stats array so user knows which is which
        [SerializeField]
        private string[] statNames;
        private const int maxStatNum = 10;
        public CharacterStats()
        {
            stats = new CharacterStat[maxStatNum];
            statNames = new string[maxStatNum];
            AddStat(StatType.Health, 100);
            AddStat(StatType.MaxHealth, 100);
            AddStat(StatType.Attack, 1);
            AddStat(StatType.Armor, 1);
            AddStat(StatType.CdReduction, 0);
            AddStat(StatType.CritChance, .03f);
            AddStat(StatType.CritDamage, 0);
            AddStat(StatType.Evade, 0);
            AddStat(StatType.RunSpeed, 5);
        }
        public void AddStat(StatType statType, float baseValue)
        {
            stats[(int)statType] = new CharacterStat(baseValue);
            statNames[(int)statType] = statType.ToString();
        }
        public CharacterStat GetStat(StatType statType)
        {
            return stats[(int)statType];
        }

        public void Load(string savedData)
        {
            JsonUtility.FromJsonOverwrite(savedData, this);
        }
    }
}
