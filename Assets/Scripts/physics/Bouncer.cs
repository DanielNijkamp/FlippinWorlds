using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private float _explosionStrength;
    void OnCollisionEnter(Collision _other)
    {
        _other.rigidbody.AddExplosionForce(_explosionStrength, transform.position, 2f);
    }
}