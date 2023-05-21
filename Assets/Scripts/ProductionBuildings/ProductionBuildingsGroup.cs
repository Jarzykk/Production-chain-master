using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ProductuinBuildingsPositions))]
public class ProductionBuildingsGroup : MonoBehaviour
{
    [SerializeField] private ProductionBuillding[] _productionsWithoutInput;
    [SerializeField] private ProductionBuildingWithInput[] _productionsWithInput;

    private ProductuinBuildingsPositions _productionBuildingPositions;

    public event UnityAction<string> FullOutputStorageProductionStopped;
    public event UnityAction<string> EmptyInputStorageProductionStopped;

    private void OnEnable()
    {
        SubscribeToProductionEvents();

        //_productionBuildingPositions = GetComponent<ProductuinBuildingsPositions>();
    }

    private void OnDisable()
    {
        UnsubscribeFromProductionEvents();
    }

    private void Start()
    {
        //SetBuildingsPositions();
    }

    public Transform[] GetProductionBuildingsPositions()
    {
        Transform[] positions = new Transform[_productionsWithInput.Length + _productionsWithoutInput.Length];
        int indexCount = 0;

        foreach (var building in _productionsWithoutInput)
        {
            positions[indexCount] = building.transform;
            indexCount++;
        }

        foreach (var building in _productionsWithInput)
        {
            positions[indexCount] = building.transform;
            indexCount++;
        }

        return positions;
    }

    private void SetBuildingsPositions()
    {
        int indexCount = 0;
        Transform[] positions = _productionBuildingPositions.GetShuffleProductionBuildingsPositions();

        foreach (var building in _productionsWithoutInput)
        {
            building.transform.position = positions[indexCount].position;
            indexCount++;
        }

        foreach (var building in _productionsWithInput)
        {
            building.transform.position = positions[indexCount].position;
            indexCount++;
        }
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
