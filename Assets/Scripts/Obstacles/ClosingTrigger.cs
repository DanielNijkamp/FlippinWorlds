using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ClosingTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggerEnter;
    private void OnTriggerEnter(Collider other)
    {
        _onTriggerEnter?.Invoke();
    }
}
