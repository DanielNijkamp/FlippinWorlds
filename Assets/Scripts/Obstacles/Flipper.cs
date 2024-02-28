using UnityEngine;
using UnityEngine.Events;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float _strength;
    [SerializeField] private float _range;
    [SerializeField] private UnityEvent _onFlung;
    
    public void Fling(GameObject target)
    {
        if (Vector3.Distance(target.transform.position, transform.position) <= _range)
        {
            var transform1 = transform;
            var flipDirection = (target.transform.position - transform1.position).normalized + transform1.up;
            target.GetComponent<Rigidbody>().AddForce(flipDirection * _strength);
            
            _onFlung?.Invoke();
        }
    }
}
