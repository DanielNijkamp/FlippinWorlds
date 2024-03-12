using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LifePowerUp : PowerUp
{
    [SerializeField] private LifeSystem _lifeSystem;
    protected override void OnPickup()
    {
        _lifeSystem.AddPoints("1");
    }
}
