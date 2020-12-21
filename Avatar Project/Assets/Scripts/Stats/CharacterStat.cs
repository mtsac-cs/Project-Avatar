using System.Security;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Assets.Scripts.Stats.Enums;

namespace Assets.Scripts.Stats
{
    [System.Serializable]
    public class CharacterStat
    {
        public float baseValue;
        internal event Action AttributeChanged;
        internal float BaseValue
        {
            get
            {
                return baseValue;
            }
            set
            {
                if (baseValue != _value)
                {
                    baseValue = _value;
                    isDirty = true;
                    if (AttributeChanged != null)
                    {
                        AttributeChanged();
                    }
                }
            }
        }
        protected float lastBaseValue = float.MinValue;
        protected readonly List<StatModifier> statModifiers;
        public readonly ReadOnlyCollection<StatModifier> StatModifiers;
        protected bool isDirty = true;
        protected float _value;
        public virtual float value
        {
            get
            {
                if (isDirty || lastBaseValue != baseValue)
                {
                    lastBaseValue = baseValue;
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
                return _value;
            }
        }

        public CharacterStat()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        public CharacterStat(float _baseValue) : this()
        {
            baseValue = _baseValue;
        }

        public virtual void AddModifier(StatModifier mod)
        {
            isDirty = true;
            statModifiers.Add(mod);
            //sorts the list by the modifier order
            //could use a sorted dictionary but modifier list
            //should never get long enough to cause a noticable impact
            //on performance
            statModifiers.Sort(CompareModifierOrder);
        }

        public virtual bool RemoveModifier(StatModifier mod)
        {
            if (statModifiers.Remove(mod))
            {
                isDirty = true;
                return true;
            }
            return false;
        }

        public virtual bool RemoveAllModifiersFromSource(object _source)
        {
            bool didRemove = false;

            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].source == _source)
                {
                    isDirty = true;
                    didRemove = true;
                    statModifiers.RemoveAt(i);
                }
            }
            return didRemove;
        }

        protected virtual float CalculateFinalValue()
        {
            float finalValue = baseValue;
            float sumPercentAdd = 0; // holds the sum of our "PercentAdd" modifiers
            for (int i = 0; i < statModifiers.Count; i++)
            {
                StatModifier mod = statModifiers[i];

                if (mod.type == StatModType.Flat)
                {
                    finalValue += mod.value;
                }
                else if (mod.type == StatModType.PercentAdd)
                {
                    sumPercentAdd += mod.value;

                    // If we're at the end of the list OR the next modifer isn't of this type
                    if (i + 1 >= statModifiers.Count || statModifiers[i + 1].type != StatModType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;// Multiply the sum with the "finalValue", like we do for "PercentMult" modifiers
                        sumPercentAdd = 0; // Reset the sum back to 0
                    }
                }
                else if (mod.type == StatModType.PercentMult)
                {
                    finalValue *= 1 + mod.value;
                }
            }
            // Rounding gets around dumb float calculation errors (like getting 12.0001f, instead of 12f)
            // 4 significant digits is usually precise enough, but feel free to change this to fit your needs
            return (float)Math.Round(finalValue, 4);
        }

        protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if (a.order < b.order)
                return -1;
            else if (a.order > b.order)
                return 1;
            return 0; // if (a.Order == b.Order)
        }
    }
}

