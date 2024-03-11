using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoints : PowerUp
{
    [SerializeField] private HighscoreSystem _highScoreSystem;
    float waitForSeconds = 20f;
    protected override void OnPickup()
    { 
      StartCoroutine(MultiplyPoints());
    }

    IEnumerator MultiplyPoints()
    {
        Debug.Log("timer Started");
        _highScoreSystem.SetScoreMultiplier(2);
        yield return new WaitForSeconds(waitForSeconds);
        _highScoreSystem.SetScoreMultiplier(1);
        Debug.Log("TimerEnded");
    }
}