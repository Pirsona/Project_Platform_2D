using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _moneyCost = 1;

    public event Action<Money> OnCollected;
    public int Cost => _moneyCost;

    public void Collect()
    {
        OnCollected?.Invoke(this);
    }
}
