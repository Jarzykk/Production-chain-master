using System.Collections.Generic;
using UnityEngine;

public class UIMessages : MonoBehaviour
{
    [SerializeField] private PopupWindow _popupWindow;
    [SerializeField] private ProductionBuildingsGroup _productionBuildingsGroup;

    private Queue<string> _messagesQueue = new Queue<string>();

    private void OnEnable()
    {
        _productionBuildingsGroup.FullOutputStorageProductionStopped += OnOutputStorageFilled;
        _productionBuildingsGroup.EmptyInputStorageProductionStopped += OnInputStorageFilled;

        _popupWindow.WindowClosed += OnPopupWindowClosed;
    }

    private void OnDisable()
    {
        _productionBuildingsGroup.FullOutputStorageProductionStopped -= OnOutputStorageFilled;
        _productionBuildingsGroup.EmptyInputStorageProductionStopped -= OnInputStorageFilled;

        _popupWindow.WindowClosed -= OnPopupWindowClosed;
    }

    private void AddMessageQueue(string message)
    {
        _messagesQueue.Enqueue(message);

        if(_popupWindow.WindowIsShowing == false)
            ShowMessage();
    }

    private void OnOutputStorageFilled(string resourceName)
    {
        string message = $"Production of {resourceName.ToLower()} is stopped.\nStorage is full";
        AddMessageQueue(message);
    }

    private void OnInputStorageFilled(string resourceName)
    {
        string message = $"Production of {resourceName.ToLower()} is stopped.\nResources for production ran out";
        AddMessageQueue(message);
    }

    private void ShowMessage()
    {
        string message = _messagesQueue.Dequeue();
        _popupWindow.ShowWindow(message);
    }

    private void OnPopupWindowClosed()
    {
        if (_messagesQueue.Count > 0)
            ShowMessage();
    }
}
