using UnityEngine.Events;

public class WinScreen : Screen
{
    public event UnityAction WinScreenAppeared;

    private void OnEnable()
    {
        BaseOnEnable();
        WinScreenAppeared?.Invoke();
    }
}
