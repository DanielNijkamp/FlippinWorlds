using System;
using UnityEngine;

namespace Input
{
    public class InputToggle : MonoBehaviour
    {
        [SerializeField] private GameObject _leftArea;
        [SerializeField] private GameObject _rightArea;
        [SerializeField] private GameObject _slider;
        
        public void ToggleInput()
        {
            var leftEnabled = _leftArea.activeSelf;
            var rightEnabled = _rightArea.activeSelf;
            var sliderEnabled = _slider.activeSelf;
            
            
            _leftArea.SetActive(!leftEnabled);
            _rightArea.SetActive(!rightEnabled);
            _slider.SetActive(!sliderEnabled);
        }
    }
}

