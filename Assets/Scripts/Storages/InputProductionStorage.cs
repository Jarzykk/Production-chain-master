using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProductionStorage : InputStorage
{
    [SerializeField] ProductionBuildingWithInput _productionBuilding;

    private void Start()
    {
        foreach (var resource in _productionBuilding.ResourceToConsume)
        {
            AddResourceToStorageList(resource);
        }
    }
}
