using UnityEngine;
using UnityEngine.Events;

namespace Obstacles
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public sealed class ForceCollider : MonoBehaviour  
    {
        [SerializeField] private float _strength;
        [SerializeField] private float _radius;
        
        [SerializeField] private UnityEvent _onCollision;
    
        private void OnCollisionEnter(Collision collision)
        {
            collision.rigidbody.AddExplosionForce(_strength, transform.position, _radius);
            _onCollision?.Invoke();
        }
    }
}


