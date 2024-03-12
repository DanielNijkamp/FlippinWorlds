using System.Collections;
using UnityEngine;

public class DoubleBalls : PowerUp
{
    [SerializeField] private GameObject _targetObject;
    [SerializeField] private float _effectDuration;
    
    private GameObject _copiedObject;
    
    protected override void OnPickup()
    {
        if (_copiedObject == null) 
        {
            StartCoroutine(Copy());
        }
    }
    private IEnumerator Copy()
    {
        _copiedObject = Instantiate(_targetObject, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(_effectDuration);
        Destroy(_copiedObject);
        _copiedObject = null;
    }

    public bool IsCopy()
    {
        return _copiedObject != null;
    }
}