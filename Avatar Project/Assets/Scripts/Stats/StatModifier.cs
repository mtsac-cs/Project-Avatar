using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.Stats.Enums;

namespace Assets.Scripts.Stats
{
    public class StatModifier
    {
        public readonly int order;
        public readonly float value;
        public readonly StatModType type;
        public readonly object source;

        // "Main" constructor. Requires all variables.
        public StatModifier(float _value, StatModType _type, int _order, object _source)
        {
            value = _value;
            type = _type;
            order = _order;
            source = _source;
        }

        // Requires Value and Type. Calls the "Main" constructor and sets Order and Source to their default values: (int)type and null, respectively.
        public StatModifier(float _value, StatModType _type) : this(_value, _type, (int)_type, null) { }

        // Requires Value, Type and Order. Sets Source to its default value: null
        public StatModifier(float _value, StatModType _type, int _order) : this(_value, _type, _order, null) { }

        // Requires Value, Type and Source. Sets Order to its default value: (int)Type
        public StatModifier(float _value, StatModType _type, object _source) : this(_value, _type, (int)_type, _source) { }
    }

}
