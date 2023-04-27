using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelConditions : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importamtSceneObjects;

    public event UnityAction PlayerWon;
    public event UnityAction PlayerLoose;

    private void OnEnable()
    {
        _importamtSceneObjects.PlayersMoney.TargetMoneyAmountCollected += CallOnWinEvent;
        _importamtSceneObjects.LevelsTimer.TimerRanOut += CallOnLooseEvent;
    }

    private void OnDisable()
    {
        _importamtSceneObjects.PlayersMoney.TargetMoneyAmountCollected += CallOnWinEvent;
        _importamtSceneObjects.LevelsTimer.TimerRanOut += CallOnLooseEvent;
    }

    private void CallOnWinEvent()
    {
        PlayerWon?.Invoke();
    }

    private void CallOnLooseEvent()
    {
        PlayerLoose?.Invoke();
    }
}
