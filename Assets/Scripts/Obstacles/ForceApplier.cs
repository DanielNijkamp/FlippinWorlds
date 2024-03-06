using UnityEngine;
using UnityEngine.Events;

namespace Obstacles
{
    public class ForceApplier : MonoBehaviour
    {
        [SerializeField] protected UnityEvent _onForceApplication;

        [SerializeField] protected float _strength;
        [SerializeField] protected float _radius;

        public void ApplyForce(GameObject target)
        {
            target.GetComponent<Rigidbody>().AddExplosionForce(_strength, transform.position, _radius);
            _onForceApplication?.Invoke();
        }
    }
}
