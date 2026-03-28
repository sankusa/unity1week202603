using System;
using UnityEngine;

namespace ShirohataLabo.u1w202603
{
    public class TabletTurner
    {
        readonly Tablet _tablet;
        readonly double _damping = 2;
        double _additionalSpeed = 0;
        public double AdditionalSpeed { get => _additionalSpeed; set => _additionalSpeed = value; }

        public TabletTurner(Tablet tablet)
        {
            _tablet = tablet;
        }

        public void Tick()
        {
            _additionalSpeed *= Math.Exp(-_damping * Time.deltaTime);

            _tablet.AddAngle(_additionalSpeed * Time.deltaTime);
        }

        public void AddAdditionalSpeed(double value) => _additionalSpeed += value;
    }
}