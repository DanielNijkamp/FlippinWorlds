using System;
using System.Collections;
using System.Collections.Generic;
using Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.Splines;

namespace Obstacles
{
    [RequireComponent(typeof(Collider))]
    public sealed class Rails : MonoBehaviour
    {
        [SerializeField] private CameraPositioner _cameraPositioner;
        [SerializeField] private SplineAnimate _splineAnimate;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private InputToggle _input;

        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _ball;
        
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = _player.GetComponent<Rigidbody>();
        }
        
        private IEnumerator ActivateRails()
        {
            ToggleVisuals();
            yield return new WaitForSeconds(0.05f);
            _cameraPositioner.TogglePosition();
            _input.ToggleInput();
            PlayAnimation();
            TransportPlayer();
            yield return new WaitForSeconds(_splineAnimate.Duration);
            ToggleVisuals();
            _cameraPositioner.TogglePosition();
            _input.ToggleInput();
        }
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(ActivateRails());
        }

        private void PlayAnimation()
        {
            _splineAnimate.MaxSpeed = _rigidbody.velocity.magnitude * 1.5f;
            _splineAnimate.Play();
        }

        private void ToggleVisuals()
        {
            var ballEnabled = _ball.activeSelf;
        
            _player.SetActive(ballEnabled);
            _ball.SetActive(!ballEnabled);
        }

        private void TransportPlayer()
        {
            _player.transform.position = _endPoint.position;
        }
    
    }
}

