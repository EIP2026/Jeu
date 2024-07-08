using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ColorblindFilter.Scripts
{
    public class FilterController : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private TMP_Dropdown dropdown;

        public void UseFilter() =>
            ColorblindFilterManager.Instance.SetUseFilter(toggle.isOn);

        public void ChangeBlindType() =>
            ColorblindFilterManager.Instance.SetBlindType((BlindnessType)dropdown.value);
    }
}
