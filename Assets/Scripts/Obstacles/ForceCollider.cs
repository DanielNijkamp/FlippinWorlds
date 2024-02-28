using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class ForceCollider : MonoBehaviour
{
    [SerializeField] private UnityEvent _onCollision;
    [SerializeField] private float _strength;
    [SerializeField] private float _radius;

    public void OnCollisionEnter(Collision other)
    {
        other.rigidbody.AddExplosionForce(_strength, transform.position, _radius);
        Debug.Log("Collision"); //check if event is not invoked multiple times per frame
        _onCollision?.Invoke();
    }
}
