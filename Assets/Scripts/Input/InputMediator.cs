using System;
using System.Collections;
using System.Collections.Generic;
using Input;
using Obstacles;
using UnityEngine;

public class InputMediator : MonoBehaviour
{
    [SerializeField] private Flipper[] _baseFlippers;
    [SerializeField] private Flipper[] _spaceFlippers;

    [SerializeField] private Flipper[] _currentFlippers;
    
    public void SwapSkins()
    {
        _currentFlippers = _currentFlippers == _baseFlippers 
            ? _spaceFlippers 
            : _baseFlippers; 
    }

    public void Flip(int index)
    {
        _currentFlippers[index].Flip();
       
    }
}
