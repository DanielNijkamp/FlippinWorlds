using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _first;
    [SerializeField] private GameObject _second;
    
    [field: SerializeField] public GameObject CurrentSkin { get; private set; }

    private void Start()
    {
        CurrentSkin.SetActive(true);
    }
    
    public void SwitchSkin()
    {
        CurrentSkin = CurrentSkin == _first ? _second : _first;
    }
}
