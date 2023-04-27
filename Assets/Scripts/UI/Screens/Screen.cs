using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        BaseOnEnable();
    }

    private void OnDisable()
    {
        BaseOnDisable();
    }

    protected void BaseOnEnable()
    {
        _restartButton.onClick.AddListener(Restart);
        _exitButton.onClick.AddListener(ExitGame);
    }

    protected void BaseOnDisable()
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
