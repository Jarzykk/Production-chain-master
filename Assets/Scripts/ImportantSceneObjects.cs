using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantSceneObjects : MonoBehaviour
{
    [SerializeField] private PlayersMoney _playersMoney;
    [SerializeField] private Player _player;
    [SerializeField] private LevelsTimer _levelsTimer;
    [SerializeField] private SceneUI _sceneUI;
    [SerializeField] private ProductionBuildingsGroup _productionBuildingGroup;
    [SerializeField] private LevelsData _levelsData;
    [SerializeField] private LevelConditions _levelConditions;

    public PlayersMoney PlayersMoney => _playersMoney;
    public Player Player => _player;
    public LevelsTimer LevelsTimer => _levelsTimer;
    public SceneUI SceneUI => _sceneUI;
    public ProductionBuildingsGroup ProductionBuildingGroup => _productionBuildingGroup;
    public LevelsData LevelsData => _levelsData;
    public LevelConditions LevelConditions => _levelConditions;
}
