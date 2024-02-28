using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    private RaycastHit _hit;

    void FixedUpdate()
    {
        // Perform a raycast downwards from the ball's position
        if (Physics.Raycast(transform.position, -transform.up, out _hit, 100f, _layerMask))
        {
            // If the raycast hits something with the "Backboard" tag, set the ball's Y position to the hit point's Y postion
            transform.position = new Vector3(transform.position.x, _hit.point.y + 0.01f, transform.position.z);
        }
    }
}



