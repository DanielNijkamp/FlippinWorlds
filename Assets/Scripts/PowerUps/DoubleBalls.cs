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
            extraBall = Instantiate(_targetObject, transform.position, Quaternion.identity);
            hasInstantiated = true;

            yield return new WaitForSeconds(waitForSeconds);
            Destroy(extraBall);
            hasInstantiated=false;
            Debug.Log("Double Ball Timer Ended");
        }
    }
}