using UnityEngine.Events;
public interface IScoreSystem 
{
    int _score { get; set; }
    UnityEvent<int> _onValueChanged { get;  set; }


    void AddPoints(string value);
}
