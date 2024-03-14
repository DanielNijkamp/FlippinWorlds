using System.Collections;
using UnityEngine;

public sealed class DoubleBalls : PowerUp
{
    [SerializeField] private GameObject _targetObject;
    [SerializeField] private float _effectDuration;
    [SerializeField] private string _copyTag;
    
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
        _copiedObject.tag = _copyTag;
        yield return new WaitForSeconds(_effectDuration);
        Destroy(_copiedObject);
        _copiedObject = null;
    }
}