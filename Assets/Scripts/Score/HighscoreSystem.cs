using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class HighscoreSystem : MonoBehaviour , ScoreSystem
{
    [Header("Config")]
    [SerializeField] private ObstacleValue _obstacleValues;
    public UnityEvent<int> _onValueChanged { get; set; } = new UnityEvent<int>();
    public float ScoreMultiplier = 1;
    private int _credits;
    public int _score { get; set; }

    private void Awake()
    {
        //_onValueChanged.AddListener();
    }


    public void AddPoints(string value)
    {
        ObstacleTypes type = value.Parse<ObstacleTypes>();
        switch (type)
        {
            case ObstacleTypes.Coin:
                _score += CalculateMultiplierBonus(_obstacleValues.Coins);
                break;
            case ObstacleTypes.Bouncer:
                _score += CalculateMultiplierBonus(_obstacleValues.Bouncer);
                break;
            case ObstacleTypes.Booster:
                _score += CalculateMultiplierBonus(_obstacleValues.Boosters);
                break;
            case ObstacleTypes.Portal:
                _score += CalculateMultiplierBonus(_obstacleValues.Portal);
                break;
            case ObstacleTypes.SmallBouncer:
                _score += CalculateMultiplierBonus(_obstacleValues.SmallBouncer);
                break;
            case ObstacleTypes.TurningDoor:
                _score += CalculateMultiplierBonus(_obstacleValues.TurningDoor);
                break;
            default:
                print("Could not find the Obect type");
                break;
        }
    }
    private int CalculateMultiplierBonus(int number)
    {
        return (int)(number * ScoreMultiplier);
    }
    public int CreditsConversion(int score)
    {
        float convertedCredits = score * 0.20f;
        return (int)convertedCredits;
    }
}
