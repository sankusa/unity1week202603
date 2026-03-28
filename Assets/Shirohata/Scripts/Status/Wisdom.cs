using System;
using R3;
using UnityEngine;

namespace ShirohataLabo.u1w202603
{
    [Serializable]
    public class Wisdom
    {
        [SerializeField] SerializableReactiveProperty<double> _value = new();
        public ReadOnlyReactiveProperty<double> Value => _value;

        public void Add(double value)
        {
            _value.Value += value;
        }
    }
}