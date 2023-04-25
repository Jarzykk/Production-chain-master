using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUI : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private LooseScreen _looseScreen;

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
    }
}
