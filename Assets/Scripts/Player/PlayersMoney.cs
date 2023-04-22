using UnityEngine;
using UnityEngine.Events;

public class PlayersMoney : MonoBehaviour
{
    private int _moneyAmount = 0;

    public int MoneyAmount => _moneyAmount;

    public event UnityAction<int> MoneyAmountChanged;

    public void AddMoney(int amount)
    {
        _moneyAmount += amount;
        MoneyAmountChanged?.Invoke(_moneyAmount);
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
