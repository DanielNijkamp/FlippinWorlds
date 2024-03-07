using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoints : PowerUp
{
    //double bounce add small script bounce script on ball with two methods one for bounce
    //powerup needs methods called to make mass smaller and bigger mass and scale
    //double balls powerup add another ball script ball duplicator method duplicate object in script and after 30 sec destroy object duplicated
    //guard rail
    //add life script
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
        //Debug.Log(_highScoreSystem.SetScoreMultiplier);
        Debug.Log("TimerEnded");
    }
}