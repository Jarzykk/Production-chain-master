using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradePost : MonoBehaviour
{
    [Header("Resources")]
    [SerializeField] private Resource[] _resourcesToSell;

    [Header("Prices")]
    [SerializeField] private int _haySellPrice = 1;
    [SerializeField] private int _wollSellPrice = 2;
    [SerializeField] private int _toyBoxSellPrice = 3;

    public Resource[] ResourcesToSell => _resourcesToSell;
}
