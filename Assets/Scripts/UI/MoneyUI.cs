using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyAmountText;
    [SerializeField] private SceneUI _sceneUI;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private int _targetMoneyAmount;
    private PlayersMoney _playersMoney;

    private void Awake()
    {
        _playersMoney = _importantSceneObjects.PlayersMoney;
    }

    private void OnEnable()
    {
        _playersMoney.MoneyAmountChanged += ChangeMoneyAmount;
    }

    private void OnDisable()
    {
        _playersMoney.MoneyAmountChanged -= ChangeMoneyAmount;
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
