using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Input
{
    [RequireComponent(typeof(VisualElement))]
    public class InputArea : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private UnityEvent _onTouch;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _onTouch?.Invoke();
        }
    }
}
