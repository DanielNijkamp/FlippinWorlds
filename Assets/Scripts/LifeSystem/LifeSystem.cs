using UnityEngine;
using UnityEngine.Events;

public class LifeSystem : MonoBehaviour, IScoreSystem
{
    public int _score { get; set; }
    public UnityEvent<int> _onValueChanged { get; set; }



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
}
