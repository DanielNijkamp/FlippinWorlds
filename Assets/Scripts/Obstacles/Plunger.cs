using System.Collections;
using Obstacles;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Plunger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    [SerializeField] private GameObject _plunger;
    
    
    [SerializeField] private GameObject _ball;
    
    [SerializeField] private Vector3 _defaultPosition;
    [SerializeField] private Vector3 _maxPullPosition;
    [SerializeField] private float _plungerForce;

    private Rigidbody _plungerRigidbody;
    
    
    public void Start()
    {
        _slider.onValueChanged.AddListener(SetPosition);
        _plungerRigidbody = _plunger.GetComponent<Rigidbody>();
    }
    
    private void SetPosition(float value)
    {
        _plungerRigidbody.MovePosition(Vector3.Lerp(_defaultPosition, _maxPullPosition, value));
    }
    
    public void ResetPosition()
    {
        StartCoroutine(ResetPlunger());
    }
    private IEnumerator ResetPlunger()
    {
        while (_slider.value < _slider.maxValue)
        {
            _slider.value += _plungerForce * Time.deltaTime;
            SetPosition(_slider.value);
            yield return null;
        }
        
    }
    
}
