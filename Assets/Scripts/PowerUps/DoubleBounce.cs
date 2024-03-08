using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : PowerUp
{
    [SerializeField] private GameObject _targetObject;
    private float waitForSeconds = 5f;
    private bool isPowerActive = false;
    private bool hasAppliedEffect = false;

    // Store the original size and mass before applying modifications
    private Vector3 originalSize;
    private float originalMass;

    protected override void OnPickup()
    {
        StartCoroutine(ActivatePower());
    }

    private IEnumerator ActivatePower()
    {
        isPowerActive = true;

        // Check if the effect has not been applied yet
        if (!hasAppliedEffect)
        {
            // Store the original size and mass
            originalSize = _targetObject.transform.localScale;

            Rigidbody rb = _targetObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                originalMass = rb.mass;
            }

            // Make the ball smaller and reduce mass
            StartCoroutine(ModifyBallPropertiesOverTime(0.8f, 0.8f, 1f));

            // Set the flag to true to indicate that the effect has been applied
            hasAppliedEffect = true;
        }

        yield return new WaitForSeconds(waitForSeconds);

        // Revert changes after the power-up duration
        StartCoroutine(ModifyBallPropertiesOverTime(1f, 1f, 1f));

        // Reset the flag after the power-up duration
        hasAppliedEffect = false;

        isPowerActive = false;
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

            // Modify mass (if Rigidbody is present)
            Rigidbody rb = _targetObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass = Mathf.Lerp(startMass, targetMass, elapsedTime / duration);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final values are set
        _targetObject.transform.localScale = targetSize;

        Rigidbody finalRb = _targetObject.GetComponent<Rigidbody>();
        if (finalRb != null)
        {
            finalRb.mass = targetMass;
        }
    }
}