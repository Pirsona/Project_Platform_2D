using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
[RequireComponent (typeof(Health))]
public class PlayerCollector : MonoBehaviour
{
    private PlayerInventory _inventory;
    private Health _health;

    private void Start()
    {
        _inventory = GetComponent<PlayerInventory>();
        _health = GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            _inventory.AddMoney(money.Cost);
            money.Collect();
        }

        if(collision.gameObject.TryGetComponent(out Heal heal))
        {
            if (_health.Current < _health.Max)
            {
                _health.Heal(heal.Replenish);
                heal.Collect();
            }
        }
    }
}
