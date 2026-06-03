using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _max;

    private float _min = 0;

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
        Current = Mathf.Max(Current - count, _min);

        if (Current <= _min)
        {
            Died?.Invoke();
        }

        ValueChanged?.Invoke();
    }
}