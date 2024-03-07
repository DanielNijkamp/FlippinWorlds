using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : PowerUp
{
    [SerializeField] private HighscoreSystem _highScoreSystem;
    float waitForSeconds = 5f;
    protected override void OnPickup()
    {
        StartCoroutine(test());
    }
    private IEnumerator test()
    {
        // Debug.Log("Double Bounce");
        Debug.Log("timer Started");
        yield return new WaitForSeconds(waitForSeconds);
        //Debug.Log(_highScoreSystem.SetScoreMultiplier);
        Debug.Log("TimerEnded");
    }
}
