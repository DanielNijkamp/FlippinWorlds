using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DoublePoints : PowerUp
{
    [SerializeField] private HighscoreSystem _highScoreSystem;
    [SerializeField] private float _effectDuration;
    protected override void OnPickup()
    { 
        StartCoroutine(MultiplyPoints());
    }

    private IEnumerator MultiplyPoints()
    {
        _highScoreSystem.SetScoreMultiplier(2);
        yield return new WaitForSeconds(_effectDuration);
        _highScoreSystem.SetScoreMultiplier(1);
    }
}