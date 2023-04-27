using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneUI : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private LooseScreen _looseScreen;
    [SerializeField] private WinScreen _winScreen;

    public ImportantSceneObjects ImportantSceneObjects => _importantSceneObjects;

    public event UnityAction ScreenEnabled;

    private void OnEnable()
    {
        _importantSceneObjects.LevelConditions.PlayerLoose += EnableLooseScreen;
        _importantSceneObjects.LevelConditions.PlayerWon += EnableWinScreen;
    }

    private void OnDisable()
    {
        _importantSceneObjects.LevelConditions.PlayerLoose -= EnableLooseScreen;
        _importantSceneObjects.LevelConditions.PlayerWon -= EnableWinScreen;
    }

    private void Start()
    {
        _looseScreen.gameObject.SetActive(false);
        _winScreen.gameObject.SetActive(false);
    }

    private void EnableLooseScreen()
    {
        _looseScreen.gameObject.SetActive(true);

        ScreenEnabled?.Invoke();
    }

    private void EnableWinScreen()
    {
        _winScreen.gameObject.SetActive(true);

        ScreenEnabled?.Invoke();
    }
}
