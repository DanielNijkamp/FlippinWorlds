using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Obstacles
{
    [RequireComponent(typeof(Camera))]
    public class CameraPositioner : MonoBehaviour
    {
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Transform _endPosition;
        [SerializeField] private float _transitionTime;
        
        private bool _isStart = true;
        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        public void TogglePosition()
        {
            StopCoroutine(MoveCamera());
            StartCoroutine(MoveCamera());
        }
        private IEnumerator MoveCamera()
        {
            float t = 0.0f;
            while(t < 1)
            {
                t += Time.deltaTime / _transitionTime;

                // If it is at start, we move to end otherwise we move to start
                _camera.transform.position = _isStart 
                    ? Vector3.Lerp(_camera.transform.position, _endPosition.position, t)
                    : Vector3.Lerp(_camera.transform.position, _startPosition.position, t);
            
                yield return null; 
            }
            _isStart = !_isStart;
        }
    }
}