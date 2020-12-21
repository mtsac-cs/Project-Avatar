using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using Assets.Scripts.Stats;

public class JsonTesting : MonoBehaviour
{
    public Text text;
    public Text outputText;
    public JsonFile jsonFile;
    public CharacterStats characterStats;

    public void save(){
        //JsonFile jsonFile = new JsonFile(text.ToString());
        outputText.text = JsonUtility.ToJson(characterStats,true);
        characterStats = new CharacterStats();
    }
}
