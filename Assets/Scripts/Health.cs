using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public float CurrentHealth {get; private set;}
    public float MaxHealth => _maxHealth;

    public event Action OnDied;

    private void Start()
    {
        CurrentHealth = _maxHealth;   
    }

    public void AddHealth(float count)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + count, _maxHealth);
    }

    public void DecreaseHealth(float count)
    {
        CurrentHealth -= count;

        if (CurrentHealth <= 0)
        {
            OnDied?.Invoke();
        }
    }
} 