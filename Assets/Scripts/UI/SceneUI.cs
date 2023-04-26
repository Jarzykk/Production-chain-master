using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneUI : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private LooseScreen _looseScreen;

    public ImportantSceneObjects ImportantSceneObjects => _importantSceneObjects;

    public event UnityAction ScreenEnabled;

    private void OnEnable()
    {
        _importantSceneObjects.LevelsTimer.TimerRanOut += EnableLooseScreen;
    }

    private void OnDisable()
    {
        _importantSceneObjects.LevelsTimer.TimerRanOut -= EnableLooseScreen;
    }

    private void Start()
    {
        _looseScreen.gameObject.SetActive(false);
    }

    private void EnableLooseScreen()
    {
        _looseScreen.gameObject.SetActive(true);

        ScreenEnabled?.Invoke();
    }
}
