using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class AbilityActivator : MonoBehaviour
    {
        [SerializeField]
        List<ICommand> activeAbilities = new List<ICommand>();

        void Update()
        {
            string activatedAbility = GetActivatedAbilityThisFrame();
            if (!string.IsNullOrEmpty(activatedAbility))
            {
                ICommand command = CommandList.GetInstance(activatedAbility);
                //command.Execute(this, this.GetTargets());
                activeAbilities.Add(command);
            }

            foreach (var ability in activeAbilities)
            {
                ability.Update();
            }

            activeAbilities.RemoveAll(a => !a.IsActive);
        }

        string GetActivatedAbilityThisFrame()
        {
            return "";
        }
    }
}
