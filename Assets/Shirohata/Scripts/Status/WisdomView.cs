using TMPro;
using UnityEngine;

namespace ShirohataLabo.u1w202603
{
    public class WisdomView : MonoBehaviour
    {
        [SerializeField] TMP_Text _valueText;

        public void UpdateValue(double value)
        {
            _valueText.SetText(value.ToString("0"));
        }
    }
}