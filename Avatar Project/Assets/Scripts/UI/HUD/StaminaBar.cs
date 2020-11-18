using Assets.Scripts;
using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private PlayerData playerData;
    public Slider statSlider;

    void Start()
    {
        playerData = Game.instance.playerData;
    }

    void Update()
    {
        var statValue = playerData.survival.Stamina;
        var maxStatValue = playerData.survival.maxStamina;
        var percentFull = statValue / maxStatValue;

        statSlider.value = percentFull;
    }
}
