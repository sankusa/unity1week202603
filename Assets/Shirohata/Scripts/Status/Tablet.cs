using R3;
using UnityEngine;

namespace ShirohataLabo.u1w202603
{
    public class Tablet
    {
        readonly ReactiveProperty<double> _angle = new();
        public ReadOnlyReactiveProperty<double> Angle => _angle;

        readonly Subject<double> _onWisdomGenerated = new();
        public Observable<double> OnWisdomGenerated => _onWisdomGenerated;

        public void AddAngle(double value)
        {
            _onWisdomGenerated.OnNext(value);
            _angle.Value += value;
        }
    }
}