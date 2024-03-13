using UnityEngine;
using UnityEngine.Events;

public abstract class ScoreSystem : MonoBehaviour
{
    [field : SerializeField] protected int _score { get; set; }
    [field: SerializeField] protected UnityEvent<int> _onValueChanged;
    public int Score
    {
        get { return _score; }
        protected set
        {
            if (_score != value)
            {
                _score = value;
            }
        }
    }

    public abstract void AddPoints(string value);
}
