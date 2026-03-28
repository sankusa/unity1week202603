using System;
using R3;
using UnityEngine;

namespace ShirohataLabo.u1w202603
{
    [Serializable]
    public class ClickPower
    {
        [SerializeField] SerializableReactiveProperty<int> _level = new(1);
        public ReadOnlyReactiveProperty<int> Level => _level;

        public double Power => _level.Value;
    }
}