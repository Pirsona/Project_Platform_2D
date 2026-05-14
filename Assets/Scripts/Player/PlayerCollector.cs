using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerCollector : MonoBehaviour
{
    private PlayerInventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<PlayerInventory>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            _inventory.AddMoney(money.Cost);
            money.Collect();
        }
    }
}
