using UnityEngine;

[RequireComponent(typeof(ResourceLerpMovement))]
public class Resource : MonoBehaviour
{
    [SerializeField] private string _resourceName;
    [SerializeField] private int _resourcePrice = 1;
    [SerializeField] private ResourceLerpMovement _movement;

    public string ResourceName => _resourceName;
    public int ResourcePrice => _resourcePrice;

    private void OnEnable()
    {
        _movement.TargetReached += OnTargetReached;
    }

    private void OnDisable()
    {
        _movement.TargetReached -= OnTargetReached;
    }

    public void MoveToPoaition(Transform targetTransform)
    {
        transform.SetParent(null);
        _movement.Move(targetTransform);
    }

    private void OnTargetReached(Transform targetTransform)
    {
        if (targetTransform.GetComponent<ResourceConsumePosition>())
            Destroy(gameObject);
        else
            transform.SetParent(targetTransform);
    }
}
