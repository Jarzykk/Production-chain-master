using UnityEngine;
using UnityEngine.Events;

public class ProductionBuildingsGroup : MonoBehaviour
{
    [SerializeField] private ProductionBuillding[] _productionsWithoutInput;
    [SerializeField] private ProductionBuildingWithInput[] _productionsWithInput;

    public event UnityAction<string> FullOutputStorageProductionStopped;
    public event UnityAction<string> EmptyInputStorageProductionStopped;

    private void OnEnable()
    {
        SubscribeToProductionEvents();
    }

    private void OnDisable()
    {
        UnsubscribeFromProductionEvents();
    }

    private void SubscribeToProductionEvents()
    {
        foreach (var production in _productionsWithInput)
        {
            production.StorageFilled += OnOutputStorageFilled;
            production.InputStorageEmptied += OnInputStorageEmptied;
        }

        foreach (var production in _productionsWithoutInput)
        {
            production.StorageFilled += OnOutputStorageFilled;
        }
    }

    private void UnsubscribeFromProductionEvents()
    {
        foreach (var production in _productionsWithInput)
        {
            production.StorageFilled -= OnOutputStorageFilled;
            production.InputStorageEmptied -= OnInputStorageEmptied;
        }

        foreach (var production in _productionsWithoutInput)
        {
            production.StorageFilled -= OnOutputStorageFilled;
        }
    }

    private void OnOutputStorageFilled(string resourceName)
    {
        FullOutputStorageProductionStopped?.Invoke(resourceName);
    }

    private void OnInputStorageEmptied(string resourceName)
    {
        EmptyInputStorageProductionStopped(resourceName);
    }
}
