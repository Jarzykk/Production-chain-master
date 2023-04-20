using UnityEngine;

public class OutputStorage : Storage
{
    [SerializeField] ProductionBuillding _productionBuilding;

    private void Start()
    {
        AddResourceToStorageList(_productionBuilding.ResourceToProduce);
    }
}
