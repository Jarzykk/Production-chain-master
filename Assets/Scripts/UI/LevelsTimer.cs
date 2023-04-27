using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelsTimer : MonoBehaviour
{
    [SerializeField] private SceneUI _sceneUI;
    [SerializeField] private TMP_Text _uiText;

    private float _secondsCount;
    private int _minutes;
    private int _seconds;
    private LevelsData _levelsData;

    public event UnityAction TimerRanOut;

    private void OnEnable()
    {
        _sceneUI.ImportantSceneObjects.LevelConditions.PlayerWon += StopTimer;
    }

    private void OnDisable()
    {
        _sceneUI.ImportantSceneObjects.LevelConditions.PlayerWon -= StopTimer;
    }

    private void Start()
    {
        _levelsData = _sceneUI.ImportantSceneObjects.LevelsData;

        SetMinutesAndSeconds(_levelsData.SecondsForLevel);
        ChangeTimerUI(_minutes, _seconds);
        _secondsCount = _levelsData.SecondsForLevel;

        StartCoroutine(TimerCoroutine());
    }

    private void SetMinutesAndSeconds(float value)
    {
        _minutes = (int)value / 60;
        _seconds = (int)value % 60;

    }

    private IEnumerator TimerCoroutine()
    {
        while(_secondsCount >= 0)
        {
            _secondsCount -= Time.deltaTime;

            SetMinutesAndSeconds(_secondsCount);
            ChangeTimerUI(_minutes, _seconds);

            yield return null;
        }

        TimerRanOut?.Invoke();
    }

    private void ChangeTimerUI(int minutes, int seconds)
    {
        string secondsForUI;

        if (seconds < 10)
            secondsForUI = $"0{seconds}";
        else
            secondsForUI = seconds.ToString();

        _uiText.text = $"{minutes}:{secondsForUI}";
    }

    private void StopTimer()
    {
        StopCoroutine(TimerCoroutine());
    }    
}
