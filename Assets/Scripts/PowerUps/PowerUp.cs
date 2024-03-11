using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected float _respawnTime;
    [SerializeField] protected GameObject _model;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            OnPickup();
            Debug.Log("Double Points active");
            StartCoroutine(Respawn());
        }
        if (other.CompareTag("Ball"))
        {
            OnPickup();
            Debug.Log("Double Bounce");
            StartCoroutine(Respawn());
        }
    }
    protected abstract void OnPickup();
    private System.Collections.IEnumerator Respawn()
    {
        _model.SetActive(false);
        yield return new WaitForSeconds(_respawnTime);
        _model.SetActive(true);
    }
}
public class DoublePointsPowerUp : PowerUp
{
    protected override void OnPickup()
    {
        Debug.Log("Double Points Collected!");
    }
    private void RespawnPowerUp()
    {
        transform.position = new Vector3(0f, 1f, 0f);
    }
}

public class AnotherPowerUp : PowerUp
{
    protected override void OnPickup()
    {
        Debug.Log("Another PowerUp Collected!");
    }
}
