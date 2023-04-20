using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ResourceLerpMovement : MonoBehaviour
{
    [SerializeField] private float _lerpDuration = 1f;

    private bool _isMoving = false;

    public event UnityAction<Transform> TargetReached;

    public void Move(Transform targetPosition)
    {
        if(_isMoving == false)
        {
            StartCoroutine(FlyToTarget(targetPosition));
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(FlyToTarget(targetPosition));
        }
    }

    private IEnumerator FlyToTarget(Transform targetsTransform)
    {
        _isMoving = true;
        float targetDistance = 0.1f;
        float elapsedTime = 0;

        while (Vector3.Distance(transform.position, targetsTransform.position) > targetDistance)
        {
            transform.position = Vector3.Lerp(transform.position, targetsTransform.position, elapsedTime / _lerpDuration);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetsTransform.rotation, elapsedTime / _lerpDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetsTransform.position;
        transform.rotation = targetsTransform.rotation;

        _isMoving = false;

        TargetReached?.Invoke(targetsTransform);
    }
}
