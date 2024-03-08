using UnityEngine;
using UnityEngine.Events;

public abstract class IScoreSystem : MonoBehaviour
{
    [field : SerializeField] protected int _score { get; set; }
    [field: SerializeField] protected UnityEvent<int> _onValueChanged;


    public abstract void AddPoints(string value);
}
