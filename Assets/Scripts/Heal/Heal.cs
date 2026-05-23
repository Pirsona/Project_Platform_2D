using System;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float _replenishHealth = 30;

    public event Action<Heal> OnCollected;

    public float Replenish => _replenishHealth;

    public void Collect()
    {
        OnCollected?.Invoke(this);
    }
}
