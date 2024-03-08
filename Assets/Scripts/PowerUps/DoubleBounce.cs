using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : PowerUp
{
    [SerializeField] private GameObject _targetObject;
    private float waitForSeconds = 5f;
    private bool isPowerActive = false;
    private bool hasAppliedEffect = false;

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
            // Make the ball smaller and reduce mass
            ModifyBallProperties(0.8f, 0.8f);

            // Set the flag to true to indicate that the effect has been applied
            hasAppliedEffect = true;
        }
        yield return new WaitForSeconds(waitForSeconds);
        // Revert changes after the power-up duration
        ModifyBallProperties(2f, 2f);
        // Reset the flag after the power-up duration
        hasAppliedEffect = false;
        isPowerActive = false;
    }

    private void ModifyBallProperties(float sizeMultiplier, float massMultiplier)
    {
        if (_targetObject != null)
        {
            // Modify size
            Vector3 newSize = _targetObject.transform.localScale * sizeMultiplier;
            _targetObject.transform.localScale = newSize;

            // Modify mass
            Rigidbody rb = _targetObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass *= massMultiplier;
            }
        }
    }
}