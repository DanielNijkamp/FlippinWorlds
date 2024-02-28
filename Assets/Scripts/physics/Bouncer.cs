using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float explosionStrength = 100f;

    void OnCollisionEnter(Collision _other)
    {
      
        _other.rigidbody.AddExplosionForce(explosionStrength, transform.position, 2f);
        Debug.Log("test");
    }
}