using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    private const float Min = 0;

    [SerializeField] private float _max;
    
    public event Action Died;
    public event Action ValueChanged;

    public float Current { get; private set; }
    public float Max => _max;

    private void Awake()
    {
        Current = _max;
    }

    public void TakeHeal(float count)
    {
        Current = Mathf.Min(Current + count, _max);

        ValueChanged?.Invoke();
    }

    public void TakeDamage(float count)
    {
        Current = Mathf.Max(Current - count, Min);

        if (Current <= Min)
        {
            Died?.Invoke();
        }

        ValueChanged?.Invoke();
    }
}