using UnityEngine;

namespace Obstacles
{
    [RequireComponent(typeof(Animator))]
    public class ClosingPlate : MonoBehaviour
    {
        private Animator _animator;
        private int _isOpen;
        
        private void Start()
        {
            _isOpen = Animator.StringToHash("IsOpen");
            _animator = GetComponent<Animator>();
        }
    
        public void TogglePlate()
        {
            _animator.SetBool(_isOpen, !_animator.GetBool(_isOpen));
        }
    }
}


