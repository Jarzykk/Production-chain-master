using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyAmountText;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private void OnEnable()
    {
        _importantSceneObjects.PlayersMoney.MoneyAmountChanged += ChangeMoneyAmount;

        _moneyAmountText.text = 0.ToString();
    }

    private void OnDisable()
    {
        _importantSceneObjects.PlayersMoney.MoneyAmountChanged -= ChangeMoneyAmount;
    }

    private void ChangeMoneyAmount(int amount)
    {
        _moneyAmountText.text = amount.ToString();
    }
}
