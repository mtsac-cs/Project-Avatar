using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/BaseStats", order = 0)]

public class BaseStats : ScriptableObject {
    public int attack;
    public int armor;
    public int cdReduction;

    //assuming we will divide this value by 100 later
    public int critChance;
    //1 = 1% more damage
    public int critDamage;
    public int evade;
    public int maxHealth;
    public int runSpeed;

}
