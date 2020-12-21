using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public interface ICommand
    {
        void Execute(AbilityActivator originator, TargetingInfo targets);
        void Update();
        bool IsActive { get; }
    }
}
