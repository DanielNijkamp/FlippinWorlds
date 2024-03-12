using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBalls : PowerUp
{
    [SerializeField] private GameObject _targetObject;
    [SerializeField] private float _effectDuration;
    private GameObject _copiedObject;
    protected override void OnPickup()
    {
        StartCoroutine(Copy());
    }

    private IEnumerator Copy()
    {
            Debug.Log("Double Ball Timer Started");
            _copiedObject = Instantiate(_targetObject, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_effectDuration);
            Destroy(_copiedObject);
    }
}