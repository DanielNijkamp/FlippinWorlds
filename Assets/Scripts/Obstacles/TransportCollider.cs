using UnityEngine;
using UnityEngine.Events;

namespace Obstacles
{
    public sealed class TransportCollider : MonoBehaviour
    {
        [SerializeField] private Transform _respawnPosition;
        [SerializeField] private UnityEvent _onCollision;
        
        private void OnCollisionEnter(Collision collision)
        {
            collision.gameObject.transform.position = _respawnPosition.position;
            _onCollision?.Invoke();
        }
    }
}


