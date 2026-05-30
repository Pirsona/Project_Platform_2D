using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerInventory _inventory;

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
                _health.TakeHeal(heal.Replenish);
                heal.Collect();
            }
        }
    }
}