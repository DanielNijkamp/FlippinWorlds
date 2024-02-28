using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{


    public Transform respawnPosition; // Set this in the Unity editor to the desired respawn position

    private void OnCollisionEnter(Collision collision)
    {
        {
            // Check if the colliding object is tagged as "Ball"
            if (collision.gameObject.CompareTag("Ball"))
            {
                // Move the ball to the respawn position
                collision.gameObject.transform.position = respawnPosition.position;
            }
        }
    }
}
