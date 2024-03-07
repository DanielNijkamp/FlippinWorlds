using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : PowerUp
{
    //[SerializeField] private HighscoreSystem _highScoreSystem;
    public float lives;
    protected override void OnPickup()
    {
        lives += 1;
        Debug.Log("Extra Life Added");
    }
}
