using UnityEngine;
using UnityEngine.Events;

public class TouchInput : MonoBehaviour
{
    [SerializeField] private UnityEvent onLeftTouch;
    [SerializeField] private UnityEvent onRightTouch;

    private void Update()
    {
        if (Input.touchCount <= 0)
            return;
        
        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;
        
        (touch.position.x < Screen.width / 2 ? onLeftTouch : onRightTouch)?.Invoke();
    }
}
