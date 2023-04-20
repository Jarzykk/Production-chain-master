using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _playersTransform;

    private Vector3 _cameraOffset;

    private void Start()
    {
        _cameraOffset = transform.position - _playersTransform.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _playersTransform.transform.position + _cameraOffset;
    }
}
