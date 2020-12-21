using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public int attack{get; set;}
    public int armor{get; set;}
    public int cdReduction{get; set;}

    //to crit roll a number between 0-100 lower than critChance
    public int critChance{get; set;}
    //1 = 1% more damage
    public float critDamage{get; set;}
    public int evade{get; set;}
    public int maxHealth{get; set;}
    public int runSpeed{get; set;}
    
    public Stats(){
        attack = 0;
        armor = 0;
        cdReduction = 0;
        critChance = 0;
        critDamage = 0;
        evade = 0;
        maxHealth = 1;
        runSpeed = 1;
    }
}
