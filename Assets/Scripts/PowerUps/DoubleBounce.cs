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

    protected override void OnPickup()
    {
        StartCoroutine(ActivatePower());
    }

    private IEnumerator ActivatePower()
    {
        if (!hasAppliedEffect)
        {
            originalSize = _targetObject.transform.localScale;

            Rigidbody rb = _targetObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                originalMass = rb.mass;
            }
            StartCoroutine(ModifyBallPropertiesOverTime(0.8f, 0.8f, 1f));
            hasAppliedEffect = true;
        }
        yield return new WaitForSeconds(waitForSeconds);
        StartCoroutine(ModifyBallPropertiesOverTime(1f, 1f, 1f));
        hasAppliedEffect = false;
    }

    private IEnumerator ModifyBallPropertiesOverTime(float sizeMultiplier, float massMultiplier, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startSize = _targetObject.transform.localScale;
        float startMass = originalMass;
        Vector3 targetSize = originalSize * sizeMultiplier;
        float targetMass = originalMass * massMultiplier;

        while (elapsedTime < duration)
        {
            _targetObject.transform.localScale = Vector3.Lerp(startSize, targetSize, elapsedTime / duration);
            Rigidbody rb = _targetObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass = Mathf.Lerp(startMass, targetMass, elapsedTime / duration);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _targetObject.transform.localScale = targetSize;

        Rigidbody finalRb = _targetObject.GetComponent<Rigidbody>();
        if (finalRb != null)
        {
            finalRb.mass = targetMass;
        }
    }
}