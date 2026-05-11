using UnityEngine;

public class MoneyFactory : MonoBehaviour
{
    public void CreateMoney(Money money)
    {
        Instantiate(money, transform.position, transform.rotation);
    }
}