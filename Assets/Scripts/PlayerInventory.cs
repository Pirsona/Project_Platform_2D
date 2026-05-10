using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int _moneyCount = 0;
    public int Money => _moneyCount;

    public void AddMoney(int count)
    {
        _moneyCount += count;
    }
}
