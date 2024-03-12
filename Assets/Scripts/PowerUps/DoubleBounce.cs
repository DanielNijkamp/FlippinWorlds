using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : PowerUp
{
    [SerializeField] private GameObject _targetObject;
    private float waitForSeconds = 5f;
    private bool hasAppliedEffect = false;
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
        if (!hasAppliedEffect)
        {
            originalSize = _targetObject.transform.localScale;
            StartCoroutine(ApplyEffectOverTime(0.8f, 0.8f, 1f));
            hasAppliedEffect = true;
        }
        yield return new WaitForSeconds(waitForSeconds);
        StartCoroutine(ApplyEffectOverTime(1f, 1f, 1f));
        hasAppliedEffect = false;
    }
    private IEnumerator ApplyEffectOverTime(float sizeMultiplier, float massMultiplier, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startSize = _targetObject.transform.localScale;
        float startMass = originalMass;
        Vector3 targetSize = originalSize * sizeMultiplier;
        float targetMass = originalMass * massMultiplier;
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