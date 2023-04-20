using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class PopupWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private float _delayBeforeFadeIn;
    [SerializeField] private float _fadeInDuration;

    private Color _backgroundColor;
    private bool _windowIsShowing = false;

    public bool WindowIsShowing => _windowIsShowing;

    public event UnityAction WindowClosed;

    private void Start()
    {
        _backgroundColor = new Color(_backgroundImage.color.r, _backgroundImage.color.g, _backgroundImage.color.b);

        DisableWindow(_text, _backgroundImage);
    }

    public void ShowWindow(string messageText)
    {
        _text.gameObject.SetActive(true);
        _text.text = messageText;
        _text.alpha = 1;

        _backgroundImage.gameObject.SetActive(true);
        _backgroundImage.color = _backgroundColor;

        _windowIsShowing = true;
        StartCoroutine(DisableWindowCycle(_text, _backgroundImage));

    }

    private IEnumerator CountDelay(float delay)
    {
        float elapsedTime = 0;

        while (elapsedTime < _fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void DisableWindow(TMP_Text textToDisable, Image imageTodisable)
    {
        textToDisable.alpha = 0;
        textToDisable.gameObject.SetActive(false);

        SetImageAlphaToZero(imageTodisable);
        imageTodisable.gameObject.SetActive(false);
    }

    private void SetImageAlphaToZero(Image background)
    {
        _backgroundImage.color = new Color(background.color.r, background.color.g, background.color.b, 0);
    }

    private IEnumerator DisableWindowCycle(TMP_Text textToDisable, Image backgroundToDisable)
    {
        yield return StartCoroutine(CountDelay(_delayBeforeFadeIn));
        textToDisable.CrossFadeAlpha(0, _fadeInDuration, false);
        backgroundToDisable.CrossFadeAlpha(0, _fadeInDuration, false);

        yield return StartCoroutine(CountDelay(_fadeInDuration));
        DisableWindow(textToDisable, _backgroundImage);

        _windowIsShowing = false;
        WindowClosed?.Invoke();
    }
}
