using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    [SerializeField] private Transform _respawnPosition;
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Ball"))
            {
                collision.gameObject.transform.position = _respawnPosition.position;
            }
    }
}