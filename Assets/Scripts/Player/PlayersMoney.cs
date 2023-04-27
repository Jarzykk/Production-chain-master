using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayersMoney : MonoBehaviour
{
    private int _targetMoneyAmount;
    private int _moneyAmount = 0;

    public int MoneyAmount => _moneyAmount;

    public event UnityAction<int> MoneyAmountChanged;
    public event UnityAction TargetMoneyAmountCollected;

    private void Start()
    {
        _targetMoneyAmount = GetComponent<Player>().ImportantSceneObjects.LevelsData.TargetMoneyAmount;
    }

    public void AddMoney(int amount)
    {
        _moneyAmount += amount;
        MoneyAmountChanged?.Invoke(_moneyAmount);

        if (_moneyAmount >= _targetMoneyAmount)
            TargetMoneyAmountCollected?.Invoke();

    }

    public int GiveMoney(int amountToGive)
    {
        if (amountToGive > _moneyAmount)
            throw new System.Exception("Not enough money");

        _moneyAmount -= amountToGive;
        MoneyAmountChanged?.Invoke(_moneyAmount);

        return amountToGive;
    }
}
