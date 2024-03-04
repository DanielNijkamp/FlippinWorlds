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
    public float ScoreMultiplier { get; set; } = 1;
    private int _credits;
    public int _score { get; set; }

    private void Awake()
    {
        //subscribe to event to Update UI 
        //_onValueChanged.AddListener();
    }


    public void AddPoints(string value)
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
    }
    private int AddMultiplierBonus(int number)
    {
        return (int)(number * ScoreMultiplier);
    }
    public int CreditsConversion(int score)
    {
        float convertedCredits = score * 0.20f;
        return (int)convertedCredits;
    }
}
