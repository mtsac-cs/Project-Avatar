using Assets.Scripts;
using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private PlayerData playerData;
    public Slider statSlider;

    void Start()
    {
        playerData = Game.instance.playerData;
    }

    void Update()
    {
        var statValue = playerData.survival.Health;
        var maxStatValue = playerData.survival.maxHealth;
        var percentFull = statValue / maxStatValue;

        statSlider.value = percentFull;
    }
}
