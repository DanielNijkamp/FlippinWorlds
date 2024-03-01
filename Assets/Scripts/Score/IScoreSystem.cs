using UnityEngine.Events;
public interface ScoreSystem 
{
    int _score { get; set; }
    UnityEvent<int> _onValueChanged { get;  set; }


    void AddPoints(string value);
}
