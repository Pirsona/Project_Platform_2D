using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _moneyCost = 1;
    public int Cost => _moneyCost;
}
