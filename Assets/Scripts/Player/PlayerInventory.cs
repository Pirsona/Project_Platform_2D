using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int _moneyCount = 0;
    public int Money => _moneyCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            AddMoney(money.Cost);
            Destroy(money.gameObject);
        }
    }

    public void AddMoney(int count)
    {
        _moneyCount += count;
    }
}
