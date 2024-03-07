using System;
using UnityEngine;
using UnityEngine.UI;

public class Plunger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    [SerializeField] private GameObject _plunger;
    [SerializeField] private GameObject _ball;
    
    [SerializeField] private Vector3 _defaultPosition;
    [SerializeField] private Vector3 _maxPullPosition;
    
    public void Start()
    {
        _slider.onValueChanged.AddListener(SetPosition);
    }
    
    private void SetPosition(float value)
    {
        _plunger.transform.localPosition = Vector3.Lerp(_defaultPosition, _maxPullPosition, value);
    }
}
