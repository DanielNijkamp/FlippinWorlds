using UnityEngine;
using UnityEngine.Events;

public class LifeSystem : MonoBehaviour, IScoreSystem
{
    public int _score { get; set; } = 3;
    public UnityEvent<int> _onValueChanged { get; set; }
    public static LifeSystem Instance;
    private PlayerSpawner _playerSpawner;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()  
    {
        _playerSpawner = PlayerSpawner.Instance;
        _playerSpawner.SpawnPlayer();
    }
    public void SubtrackLife()
    {
        _score -= 1;
        _onValueChanged?.Invoke(_score);
    }
    public void AddPoints(string value)
    {
        int IntValue = int.Parse(value);
        _score += IntValue;
        _onValueChanged?.Invoke(_score);
    }
    public void RespawnPlayer()
    {
        if (_score > 0)
            _playerSpawner.SpawnPlayer();
        else
            Debug.LogError("Player is out of lifes");
    }
}
