using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyAmountText;
    [SerializeField] private SceneUI _sceneUI;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private int _targetMoneyAmount;

    private void OnEnable()
    {
        _importantSceneObjects.PlayersMoney.MoneyAmountChanged += ChangeMoneyAmount;
    }

    private void OnDisable()
    {
        _importantSceneObjects.PlayersMoney.MoneyAmountChanged -= ChangeMoneyAmount;
    }

    private void Start()
    {
        _targetMoneyAmount = _sceneUI.ImportantSceneObjects.LevelsData.TargetMoneyAmount;

        SetInitialMoneyAmount();
    }

    private void ChangeMoneyAmount(int amount)
    {
        _moneyAmountText.text = $"{amount}/{_targetMoneyAmount}";
    }

    private void SetInitialMoneyAmount()
    {
        _moneyAmountText.text = $"0/{_targetMoneyAmount}";
    }
}
