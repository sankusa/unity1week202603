using UnityEngine;
using VContainer;
using R3;

namespace ShirohataLabo.u1w202603
{
    public class TabletView : MonoBehaviour
    {
        [Inject] Tablet _tablet;

        void Start()
        {
            _tablet.Angle
                .Subscribe(value => transform.localRotation = Quaternion.Euler(0, (float)value * 360, 0))
                .AddTo(this);
        }
    }
}