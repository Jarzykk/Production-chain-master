using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionPlace : MonoBehaviour
{
    [SerializeField] private int _priceToBuild;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Image _priceImage;

    private int _moneyLeftForConstruction;
    private bool _constructed => _moneyLeftForConstruction == 0;

    private void Start()
    {
        _priceText.text = _priceToBuild.ToString();
        _moneyLeftForConstruction = _priceToBuild;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayersMoney>(out PlayersMoney playerMoney))
        {
            if(_constructed == false && playerMoney.MoneyAmount > 0)
            {
                if (_moneyLeftForConstruction <= playerMoney.MoneyAmount)
                    TakeMoney(playerMoney.GiveMoney(_moneyLeftForConstruction));
                else if (_moneyLeftForConstruction > playerMoney.MoneyAmount)
                    TakeMoney(playerMoney.GiveMoney(playerMoney.MoneyAmount));

                if (_constructed == true)
                    OnConstruction();
            }
        }
    }

    private void TakeMoney(int amount)
    {
        if (amount > _moneyLeftForConstruction)
            throw new System.Exception("Construction place is trying to take more money than it should");

        _moneyLeftForConstruction -= amount;
        _priceText.text = (_moneyLeftForConstruction).ToString();
    }

    private void OnConstruction()
    {
        _priceText.gameObject.SetActive(false);
        _priceImage.gameObject.SetActive(false);
    }
}
