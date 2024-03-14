using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Obstacles
{
    [RequireComponent(typeof(Collider))]
    public sealed class Booster : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onBoost;
        [SerializeField] private float _boostStrength;
        [SerializeField] private float _directionThreshold;
        
        private void OnTriggerEnter(Collider collision)
        {
            var relativePosition = collision.transform.position - transform.position;
            var boostDirection = relativePosition.normalized;
            
            if (relativePosition.y > _directionThreshold)
            {
                collision.gameObject
                    .GetComponent<Rigidbody>()
                    .AddForce(_boostStrength * -boostDirection, ForceMode.Impulse);
                    _onBoost?.Invoke();
            }
        }
    }
}


