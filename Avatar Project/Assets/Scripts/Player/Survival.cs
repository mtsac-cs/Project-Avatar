using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Survival stats and mechanics for player
    /// </summary>
    public class Survival : MonoBehaviour
    {
        #region Properties
        private float health = 0;
        public float Health 
        {
            get { return health; }
            set { SetHealth(value); }
        }

        public float maxHealth = 10;
        public float healthRegenAmount = 1; //How much health to regen each time health is regenerated
        public float healthTimeBetweenRegen = 3; //How long to wait per regeneration. Default 3 sec
        public float healthRegenDelayTime = 10; //After taking damage, how long to wait before starting regen


        private float stamina;
        public float Stamina
        {
            get { return stamina; }
            set { SetStamina(value); }
        }

        public float maxStamina = 10;
        public float staminaRegenAmount = 1; //How much stamina to regen each time stamina is regenerated
        public float staminaTimeBetweenRegen = 3; //How long to wait per regeneration. Default 3 sec
        public float staminaRegenDelayTime = 1.5f; //After using stamina, how long to wait before starting regen
        #endregion


        #region Unity Events
        void Update()
        {
            if (Health < maxHealth)
                RegenHealth();

            if (Stamina < maxStamina)
                RegenStamina();
        }
        #endregion


        float timeToNextHealthRegen = 0f;
        private void RegenHealth()
        {
            if (!CanRegen(timeToNextHealthRegen)) return;

            timeToNextHealthRegen = Time.time + healthTimeBetweenRegen;
            Regen(ref health, healthRegenAmount, maxHealth);  //referencing health field instead of property

            Debug.Log("Health: " + Health);
        }


        float timeToNextStaminaRegen = 0f;
        private void RegenStamina()
        {
            if (!CanRegen(timeToNextStaminaRegen)) return;
            
            timeToNextStaminaRegen = Time.time + staminaTimeBetweenRegen;
            Regen(ref stamina, staminaRegenAmount, maxStamina);  //referencing stamina field instead of property
        }


        private bool CanRegen(float timeToNextRegen) => Time.time > timeToNextRegen;

        private void Regen(ref float stat, float amout, float max)
        {
            stat += amout;

            if (stat == max)
                stat = max;
        }


        private void SetHealth(float amount)
        {
            health = amount;
            if (health < 0)
                health = 0;

            if (IsPlayerDead())
                Die();
        }

        public bool IsPlayerDead() => Health <= 0;

        private void Die()
        {
            Debug.Log("Player has died");
        }


        private void SetStamina(float amount)
        {
            stamina = amount;
            if (stamina < 0)
                stamina = 0;
        }
    }
}