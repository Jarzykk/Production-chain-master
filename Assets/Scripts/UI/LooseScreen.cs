using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LooseScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    public event UnityAction LooseScreenAppeared;

    private void OnEnable()
    {
        LooseScreenAppeared?.Invoke();

        _restartButton.onClick.AddListener(Restart);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(Restart);
        _exitButton.onClick.RemoveListener(ExitGame);
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
