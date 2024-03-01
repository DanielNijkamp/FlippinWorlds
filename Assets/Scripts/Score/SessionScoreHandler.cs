using UnityEngine.Events;
using UnityEngine;
using TMPro;

public class SessionScoreHandler : MonoBehaviour , ScoreSystem
{
    private static SessionScoreHandler _scoreHandler;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private ObstacleValue _obstacleValues;


    private int _score;
    public float _scoreMultiplier = 1;
    private void Awake()
    {
        _scoreHandler = this;
    }
    public void AddPoints(string value)
    {
        //will parse the string into a value
        ObstacleTypes type = value.Parse<ObstacleTypes>();
        switch (type)
        {
            case ObstacleTypes.Coin:
                _score += (int)(_obstacleValues.Coins * _scoreMultiplier);    
                break;
            case ObstacleTypes.Bouncer:
                _score += (int)(_obstacleValues.Bouncer * _scoreMultiplier);
                break;
            case ObstacleTypes.Booster:
                _score += (int)(_obstacleValues.Boosters * _scoreMultiplier);
                break;
            case ObstacleTypes.Portal:
                _score += (int)(_obstacleValues.Portal * _scoreMultiplier);
                break;
            case ObstacleTypes.SmallBouncer:
                _score += (int)(_obstacleValues.SmallBouncer * _scoreMultiplier);
                break;
            case ObstacleTypes.TurningDoor:
                _score += (int)(_obstacleValues.TurningDoor * _scoreMultiplier);
                break;
            default:
                print("Could not find the Obect type");
                break;
        }
        UpdateUI();
    }
   
    public void OnGameOver()
    {
        HighScoreHandler._highScoreHandler.OnGameOver(_score);
    }

    //DELETE BEFORE MERGING
    #region debugTests
    public void UpdateUI()
    {
        _scoreText.text = "Current Score: " + _score.ToString();
    }
    public void DebugButton(string value)
    {
        AddPoints(value);
    }
    
    #endregion

    public void OnGameOver(int Score) { }
}
