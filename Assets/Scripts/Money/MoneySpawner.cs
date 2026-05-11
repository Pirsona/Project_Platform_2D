using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public void CreateMoney(Money money)
    {
        Instantiate(money, transform.position, transform.rotation);
    }
}