using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsData : MonoBehaviour
{
    [SerializeField] private int _targetMoneyAmount;
    [SerializeField] private float _secondsForLevel;

    public int TargetMoneyAmount => _targetMoneyAmount;
    public float SecondsForLevel => _secondsForLevel;
}
