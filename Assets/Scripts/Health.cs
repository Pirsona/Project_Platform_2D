using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;

    public float Current {get; private set;}
    public float Max => _max;

    public event Action OnDied;

    private void Start()
    {
        Current = _max;   
    }

    public void Heal(float count)
    {
        Current = Mathf.Min(Current + count, _max);
    }

    public void TakeDamage(float count)
    {
        Current -= count;

        if (Current <= 0)
        {
            OnDied?.Invoke();
        }
    }
} 