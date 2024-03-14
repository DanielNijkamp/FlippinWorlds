using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected float _respawnTime;
    [SerializeField] private GameObject _model;
    [SerializeField] private Collider _collider;

    private void OnTriggerEnter(Collider other)
    {
        OnPickup();
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        _model.SetActive(false);
        _collider.enabled = false;
        yield return new WaitForSeconds(_respawnTime);
        _model.SetActive(true);
        _collider.enabled = true;
    }
    
    protected abstract void OnPickup();

}