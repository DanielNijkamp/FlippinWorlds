using UnityEngine;
using UnityEngine.Events;

public class LifeSystem : IScoreSystem
{
    [SerializeField] private UnityEvent _onGameOver = new UnityEvent();

    public void SubtrackLife()
    {
        _score -= 1;
        _onValueChanged?.Invoke(_score);
    }
    public override void AddPoints(string value)
    {
        int intValue = int.Parse(value);
        _score += intValue;
        _onValueChanged?.Invoke(_score);
    }
    public void CheckLifes()
    {
        if (_score == 0)
        {
            _onGameOver?.Invoke();
        }
        
    }

}
