using System.Collections;
using UnityEngine;

namespace Obstacles
{
    public sealed class DeathBarrier : TransportCollider
    {
        [SerializeField] private string _tag;
        
        protected override void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(_tag))
            {
                Destroy(collision.gameObject);
            }
            else
            {
                base.OnCollisionEnter(collision);
            }
        }
    }
}