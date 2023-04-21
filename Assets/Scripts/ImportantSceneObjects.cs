using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantSceneObjects : MonoBehaviour
{
    [SerializeField] private PlayersMoney _playersMoney;
    [SerializeField] private ProductionBuildingsGroup _productionBuildingGroup;

    public PlayersMoney PlayersMoney => _playersMoney;
    public ProductionBuildingsGroup ProductionBuildingGroup => _productionBuildingGroup;
}
