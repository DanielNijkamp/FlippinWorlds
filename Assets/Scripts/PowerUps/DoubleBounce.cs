using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DoubleBounce : PowerUp
{
    [SerializeField] private GameObject _targetObject;
    [SerializeField] private float _effectDuration;
    
    private Vector3 originalSize;
    private float originalMass;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    protected override void OnPickup()
    {
        StartCoroutine(ActivatePower());
    }

    private IEnumerator ActivatePower()
    {
        originalSize = _targetObject.transform.localScale;
        StartCoroutine(ApplyEffectOverTime(0.8f, 0.8f, 1f));
            
        yield return new WaitForSeconds(_effectDuration);
        StartCoroutine(ApplyEffectOverTime(1f, 1f, 1f));
    }
    private IEnumerator ApplyEffectOverTime(float sizeMultiplier, float massMultiplier, float duration)
    {
        var elapsedTime = 0f;
        var startSize = _targetObject.transform.localScale;
        var startMass = originalMass;
        var targetSize = originalSize * sizeMultiplier;
        var targetMass = originalMass * massMultiplier;
        
        while (elapsedTime < duration)
        {
            _targetObject.transform.localScale = Vector3.Lerp(startSize, targetSize, elapsedTime / duration);
            _rigidbody.mass = Mathf.Lerp(startMass, targetMass, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _targetObject.transform.localScale = targetSize;
        _rigidbody.mass = targetMass;
    }
}