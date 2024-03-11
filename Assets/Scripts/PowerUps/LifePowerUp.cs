using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : PowerUp
{
    public float lives;
    protected override void OnPickup()
    {
        lives += 1;
        Debug.Log("Extra Life Added");
    }
}
