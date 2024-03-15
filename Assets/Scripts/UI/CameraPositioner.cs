
using System.Collections;
using UnityEngine;

public class CameraPositioner : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private Transform[] positions;
    
    [SerializeField] private float _transitionTime;
    
    public void SetPosition(int index)
    {
        if(index < positions.Length)
        {
            StartCoroutine(MoveCamera(positions[index]));
        }
    }
    private IEnumerator MoveCamera(Transform targetPosition)
    {
        float t = 0.0f;
        Vector3 startPosition = _camera.transform.position;
        Quaternion startRotation = _camera.transform.rotation;
        while (t < 1)
        {
            t += Time.deltaTime / _transitionTime;
            _camera.transform.position = Vector3.Lerp(startPosition, targetPosition.position, t);
            _camera.transform.rotation = Quaternion.Lerp(startRotation, targetPosition.rotation, t);
            yield return null;
        }
    }
}
