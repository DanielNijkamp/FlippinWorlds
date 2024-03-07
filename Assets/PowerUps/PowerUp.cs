using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rigidbody and collider gameobject
//instantiate and destroy
//oncollision
//respawntime variable public
//onpickup method
//double points powerup and others in different classes
public abstract class PowerUp : MonoBehaviour
{
    public float respawnTime = 10f; // Adjust the respawn time in the Unity Inspector

    public GameObject model;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Assuming the PowerUp should be collected by the player
        {
            OnPickup();
            Debug.Log("Double Points");
            StartCoroutine(Respawn());
        }
    }
    protected abstract void OnPickup(); // To be implemented in derived classes
    private System.Collections.IEnumerator Respawn()
    {
        // Disable the GameObject while waiting for respawn
        model.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        // Enable the GameObject after respawn time
        model.SetActive(true);
    }
}
// Example of a derived class for a DoublePoints powerup
public class DoublePointsPowerUp : PowerUp
{
    protected override void OnPickup()
    {
        // Implement the behavior for DoublePoints powerup
        Debug.Log("Double Points Collected!");
        // Add your specific logic here
    }
private void RespawnPowerUp()
{
    // Adjust the position and rotation as needed
    transform.position = new Vector3(0f, 1f, 0f); // Set the respawn position

    // If you want to instantiate a new power-up object, you can use the following code
    // Instantiate(gameObject, new Vector3(0f, 1f, 0f), Quaternion.identity);
}
}

// Example of a derived class for another type of powerup
public class AnotherPowerUp : PowerUp
{
    protected override void OnPickup()
    {
        // Implement the behavior for the other powerup
        Debug.Log("Another PowerUp Collected!");
        // Add your specific logic here
    }
}
