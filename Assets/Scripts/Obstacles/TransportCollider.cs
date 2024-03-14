using UnityEngine;
using UnityEngine.Events;

namespace Obstacles
{
    public class TransportCollider : MonoBehaviour
    {
        [SerializeField] private Transform _respawnPosition;
        [SerializeField] private UnityEvent _onCollision;
        
        protected virtual void OnCollisionEnter(Collision collision)
        {
            collision.gameObject.transform.position = _respawnPosition.position;
            _onCollision?.Invoke();
        }
    }
}


