using UnityEngine;
using System.Collections.Generic;

namespace ColorblindFilter.Scripts
{
    public class ColorblindFilterManager : MonoBehaviour
    {
        public static ColorblindFilterManager Instance { get; private set; }

        [SerializeField] private BlindnessType _blindnessType;
        [SerializeField] private bool _useFilter = true;

        private readonly List<ColorblindFilter> _filters = new List<ColorblindFilter>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void RegisterFilter(ColorblindFilter filter)
        {
            if (!_filters.Contains(filter))
            {
                _filters.Add(filter);
                filter.ChangeBlindType(_blindnessType);
                filter.SetUseFilter(_useFilter);
            }
        }

        public void UnregisterFilter(ColorblindFilter filter)
        {
            if (_filters.Contains(filter))
            {
                _filters.Remove(filter);
            }
        }

        public void SetBlindType(BlindnessType blindnessType)
        {
            _blindnessType = blindnessType;
            foreach (var filter in _filters)
            {
                filter.ChangeBlindType(blindnessType);
            }
        }

        public void SetUseFilter(bool useFilter)
        {
            _useFilter = useFilter;
            foreach (var filter in _filters)
            {
                filter.SetUseFilter(useFilter);
            }
        }
    }
}
