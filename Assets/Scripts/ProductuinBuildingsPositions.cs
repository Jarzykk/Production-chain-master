using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProductionBuildingsGroup))]
public class ProductuinBuildingsPositions : MonoBehaviour
{
    private ProductionBuildingsGroup _productionBuildingsGroup;
    private Transform[] _productionBuildingsPositions;

    public Transform[] ProductionBuildingsPositions => _productionBuildingsPositions;

    private void Awake()
    {
        _productionBuildingsGroup = GetComponent<ProductionBuildingsGroup>();

        SetProductionBuildingsPositions(_productionBuildingsGroup);
    }

    private void SetProductionBuildingsPositions(ProductionBuildingsGroup productionBuildingGroup)
    {
        _productionBuildingsPositions = productionBuildingGroup.GetProductionBuildingsPositions();
    }

    public Transform[] GetShuffleProductionBuildingsPositions()
    {
        for (int i = 0; i < _productionBuildingsPositions.Length; i++)
        {
            int random = Random.Range(0, _productionBuildingsPositions.Length);
            var temp = _productionBuildingsPositions[i];
            _productionBuildingsPositions[i] = _productionBuildingsPositions[random];
            _productionBuildingsPositions[random] = temp;
        }

        return _productionBuildingsPositions;
    }
}
