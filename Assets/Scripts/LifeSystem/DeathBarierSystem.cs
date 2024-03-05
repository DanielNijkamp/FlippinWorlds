using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarierSystem : MonoBehaviour
{
    private LifeSystem _lifeSystem;
    private void Start()
    {
        _lifeSystem = LifeSystem.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _lifeSystem.SubtrackLife();
            _lifeSystem.RespawnPlayer();
            Destroy(other);
        }
    }
}
