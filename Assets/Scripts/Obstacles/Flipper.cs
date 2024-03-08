using UnityEngine;
using UnityEngine.Events;

namespace Obstacles
{
    [RequireComponent(typeof(HingeJoint))]
    public sealed class Flipper : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onFlip;

        [SerializeField] private float _damping;
        [SerializeField] private float _strengh;
        [SerializeField] private float _returnTime;

        [SerializeField] private bool _reversedConstraints;

        private HingeJoint _hinge;
        private float _restPosition;
        private float _pressedPosition;

        private void Start()
        {
            _hinge = GetComponent<HingeJoint>();
            
            if (_reversedConstraints)
            {
                _restPosition = _hinge.limits.max;
                _pressedPosition = _hinge.limits.min;
            }
            else
            {
                _restPosition = _hinge.limits.min;
                _pressedPosition = _hinge.limits.max;
            }
        }

        public void Flip()
        {
            SetAngle(_pressedPosition);
            _onFlip?.Invoke();

            Invoke(nameof(ReturnToRestPosition), _returnTime);
        }

        private void SetAngle(float angle)
        {
            JointSpring spring = new JointSpring
            {
                spring = _strengh,
                damper = _damping,
                targetPosition = angle
            };

            _hinge.spring = spring;
        }

        private void ReturnToRestPosition()
        {
            SetAngle(_restPosition);
        }
    } 
}