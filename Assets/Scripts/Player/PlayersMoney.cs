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
}
