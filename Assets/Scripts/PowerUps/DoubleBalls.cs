using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBalls : PowerUp
{
    [SerializeField] private GameObject _targetObject;
    float waitForSeconds = 20f;
    private bool hasInstantiated = false;
    private GameObject extraBall;

    protected override void OnPickup()
    {
        StartCoroutine(ExtraBall());
    }

    IEnumerator ExtraBall()
    {
        if (!hasInstantiated)
        {
            Debug.Log("Double Ball Timer Started");

            // Instantiate a new ball and store the reference
            extraBall = Instantiate(_targetObject, transform.position, Quaternion.identity);
            hasInstantiated = true;

            // Optionally, you can set the extraBall's position, rotation, etc., based on your requirements.
            // extraBall.transform.position = new Vector3(x, y, z);

            yield return new WaitForSeconds(waitForSeconds);

            // Destroy the extra ball after the specified duration
            Destroy(extraBall);
            Debug.Log("Double Ball Timer Ended");
        }
    }
}