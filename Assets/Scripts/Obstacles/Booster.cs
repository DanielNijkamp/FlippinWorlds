using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    //TODO: check if booster should boost:
    //in the direction the ball comes in
    //or in 1 direction only
    
    [RequireComponent(typeof(Collider))]
    public sealed class Booster : MonoBehaviour
    {
        [SerializeField] private float _boostStrength;

        private void OnTriggerEnter(Collider collision)
        {
            var boostDirection = (collision.transform.position - transform.position).normalized;
            
            collision.gameObject
                .GetComponent<Rigidbody>()
                .AddForce(_boostStrength * -boostDirection, ForceMode.Impulse);
        }
    }
}


