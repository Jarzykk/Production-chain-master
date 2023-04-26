using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantSceneObjects : MonoBehaviour
{
    [SerializeField] private PlayersMoney _playersMoney;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private LevelsTimer _levelsTimer;
    [SerializeField] private SceneUI _sceneUI;
    [SerializeField] private ProductionBuildingsGroup _productionBuildingGroup;

    public PlayersMoney PlayersMoney => _playersMoney;
    public PlayerMovement PlayerMovement => _playerMovement;
    public LevelsTimer LevelsTimer => _levelsTimer;
    public SceneUI SceneUI => _sceneUI;
    public ProductionBuildingsGroup ProductionBuildingGroup => _productionBuildingGroup;
}
