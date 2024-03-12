using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class HighscoreSystem : ScoreSystem
{
    [Header("Config")]
    [SerializeField] private ObstacleValue _obstacleValues;
    private float _scoreMultiplier { get; set; } = 1;

    private void Awake()
    {
        //subscribe to event to Update UI 
        //_onValueChanged.AddListener();
    }

    public void SetScoreMultiplier(float newMultiplier)
    {
        _scoreMultiplier = newMultiplier;
    }
    public override void AddPoints(string value)
    {
        ObstacleTypes type = value.Parse<ObstacleTypes>();
        switch (type)
        {
            case ObstacleTypes.Coin:
                _score += AddMultiplierBonus(_obstacleValues.Coins);
                break;
            case ObstacleTypes.Bouncer:
                _score += AddMultiplierBonus(_obstacleValues.Bouncer);
                break;
            case ObstacleTypes.Booster:
                _score += AddMultiplierBonus(_obstacleValues.Boosters);
                break;
            case ObstacleTypes.Portal:
                _score += AddMultiplierBonus(_obstacleValues.Portal);
                break;
            case ObstacleTypes.SmallBouncer:
                _score += AddMultiplierBonus(_obstacleValues.SmallBouncer);
                break;
            case ObstacleTypes.TurningDoor:
                _score += AddMultiplierBonus(_obstacleValues.TurningDoor);
                break;
            default:
                print("Could not find the Obect type");
                break;
        }
       // _onValueChanged?.Invoke(_score);
    }
    private int AddMultiplierBonus(int number)
    {
        return (int)(number * _scoreMultiplier);
    }
}
